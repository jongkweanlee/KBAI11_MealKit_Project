using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealKit
{
    public partial class China_Food : Form
{
    public China_Food()
    {
        InitializeComponent();
        this.Load += 중식_Load;
            if (UserDataManager.loginUser != null)
            {
                button2_Login_Click.Dispose();
            }
        }

    private void 중식_Load(object sender, EventArgs e)
    {
        // 폼이 로드될 때 양식에 해당하는 상품 로드
        DataManager.KitLoad();

        // panel1에 UC_Item 추가 및 클릭 이벤트 연결
        AddUCItemsToPanel();
    }

        private void AddUCItemsToPanel()
        {
            int itemCount = 0; // 추가된 UC_Item 개수를 세기 위한 변수
            int itemsPerRow = 3; // 한 행에 표시할 아이템 개수
            int itemWidth = 150; // 각 UC_Item의 폭
            int itemHeight = 200; // 각 UC_Item의 높이
            int horizontalSpacing = 50; // 아이템 간 가로 간격
            int verticalSpacing = 30; // 아이템 간 세로 간격

            int startX = 50; // 시작 X 좌표
            int startY = 50; // 시작 Y 좌표

            foreach (Product product in DataManager.products)
            {
                if (product.item_kind.ToLower() == "중식")
                {
                    UC_Item ucItem = new UC_Item
                    {
                        itemName = product.item_name,
                        itemPrice = $"{product.item_price:C}"
                    };

                    // 이미지를 설정
                    string imageName = product.item_name;
                    var image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);

                    if (image != null)
                    {
                        ucItem.itemImage = image;

                        // 아이템의 위치 동적 계산
                        int row = itemCount / itemsPerRow;
                        int col = itemCount % itemsPerRow;

                        int x = startX + col * (itemWidth + horizontalSpacing);
                        int y = startY + row * (itemHeight + verticalSpacing);

                        ucItem.Location = new Point(x, y);

                        // 클릭 이벤트 핸들러 등록
                        ucItem.ItemClicked += (s, e) => UC_Item_Click_중식(ucItem);   

                        panel1.Controls.Add(ucItem);
                        itemCount++; // UC_Item 추가될 때마다 개수 증가
                    }
                    else
                    {
                        Console.WriteLine($"Image '{imageName}' not found in Resources.");
                    }
                }
            }

            Console.WriteLine($"Added {itemCount} UC_Items to panel1."); // 추가된 개수 출력
        }

        private void UC_Item_Click_중식(UC_Item ucItem)   
        {
            try
            {
                // 중복된 상품이 이미 있는지 확인
                UC_CartItem existingCartItem = FindExistingCartItem(ucItem.itemName);

                if (existingCartItem != null)
                {
                    // 이미 있는 상품이라면 수량을 증가시킴
                    existingCartItem.Quantity++;
                }
                else
                {
                    // UC_CartItem 객체를 생성하고 초기화
                    UC_CartItem cartItem = new UC_CartItem();
                    cartItem.itemImage = ucItem.itemImage;
                    cartItem.itemName = ucItem.itemName;
                    cartItem.itemPrice = ucItem.itemPrice;
                    cartItem.Quantity = 1; // 초기 수량은 1

                    // 위치 계산
                    if (panel5.Controls.Count > 0)
                    {
                        UC_CartItem lastCartItem = panel5.Controls[panel5.Controls.Count - 1] as UC_CartItem;
                        if (lastCartItem != null)
                        {
                            int yOffset = lastCartItem.Bottom + 10;
                            cartItem.Location = new Point(20, yOffset);
                        }
                        else
                        {
                            cartItem.Location = new Point(20, 30);
                        }
                    }
                    else
                    {
                        cartItem.Location = new Point(20, 30);
                    }

                    // panel5에 UC_CartItem 컨트롤 추가
                    panel5.Controls.Add(cartItem);
                }
            }
            catch (Exception ex)
            {
                // 오류 발생 시 메시지 박스 표시
                MessageBox.Show($"오류: {ex.Message}");
            }
        }

        private void UC_CartItem_RemoveFromPanel(object sender, EventArgs e)
        {
            // UC_CartItem을 panel5에서 제거
            if (sender is UC_CartItem cartItem)
            {
                panel5.Controls.Remove(cartItem);
            }
        }

        // 중복된 상품이 있는지 확인하는 메서드
        private UC_CartItem FindExistingCartItem(string itemName)
        {
            foreach (Control control in panel5.Controls)
            {
                if (control is UC_CartItem cartItem && cartItem.itemName == itemName)
                {
                    return cartItem;
                }
            }
            return null;
        }

        private void button1_Main_Page_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main_Form().Show();
        }

        private void button2_Item_basket_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Item_Basket().Show();
        }

        private void button3_User_Information_Click(object sender, EventArgs e)
        {
            if (button2_Login_Click.Text.Equals("로그아웃"))
            {
                Hide();
                new My_Page().ShowDialog();
                if (Withdraw_Check.withdrawCheck == true)
                    button2_Login_Click.Text = "로그인";
            }
            else
                MessageBox.Show("로그인을 해주세요.");
            Show();
        }

        private void button7_Return_Main_Page_Click(object sender, EventArgs e)
        {
            this.Close();
            new Main_Form().ShowDialog();
        }

        private void button9_Purchase_Click(object sender, EventArgs e)
        {
            this.Hide();
            Purchase_Window frm9 = new Purchase_Window();
            foreach (UC_CartItem cartItem in panel5.Controls.OfType<UC_CartItem>())
            {
                UC_CartItem newCartItem = new UC_CartItem
                {
                    itemImage = cartItem.itemImage,
                    itemName = cartItem.itemName,
                    itemPrice = cartItem.itemPrice,
                    Quantity = cartItem.Quantity
                };
                frm9.AddCartItemToPanel(newCartItem);
            }
            frm9.Show();
        }

        private void button8_Contain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Item_Basket frm9 = new Item_Basket();
            foreach (UC_CartItem cartItem in panel5.Controls.OfType<UC_CartItem>())
            {
                UC_CartItem newCartItem = new UC_CartItem
                {
                    itemImage = cartItem.itemImage,
                    itemName = cartItem.itemName,
                    itemPrice = cartItem.itemPrice,
                    Quantity = cartItem.Quantity
                };
                frm9.AddCartItemToPanel(newCartItem);
            }
            frm9.Show();
        }

        private void button2_Login_Click_Click(object sender, EventArgs e)
        {
            if (button2_Login_Click.Text.Equals("로그인"))
            {
                Hide();
                Login frm = new Login();
                frm.ShowDialog();

                if (UserDataManager.loginUser != null)
                {
                    if (UserDataManager.isAdmin == false)
                        (sender as Button).Text = "로그아웃";
                }
                Show();
            }
            else
            {
                string ID = UserDataManager.loginUser.ID;
                string PW = UserDataManager.loginUser.Password;

                UserDataManager.loginUser = null;
                (sender as Button).Text = "로그인";
                LoginLogoutButtonCheck(ID, PW, "로그아웃");
            }
        }
        // 로그인, 로그아웃 체크
        public void LoginLogoutButtonCheck(string id, string pw, string txt)
        {
            UserDataManager.Save(id, pw, txt);
        }
    }
}
