using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealKit
{
    public partial class Item_Basket : Form
    {
        public Item_Basket()
        {
            InitializeComponent();
            label1_Item_Basket.Text = "장바구니";
            label2_Payment.Text = "결재 금액 : ";
            label3_Amount.Text = "0";           
            button4_Purchase.Text = "구매";
            if (UserDataManager.loginUser != null)
            {
                button2_Login_Click.Dispose();

            }
        }

        private double totalAmount = 0; // 총 금액을 저장할 변수
        public void AddCartItemToPanel(UC_CartItem cartItem)
        {
            // 위치 계산
            int itemCount = panel1.Controls.OfType<UC_CartItem>().Count();
            int rowIndex = itemCount / 3;
            int colIndex = itemCount % 3;

            int xOffset = colIndex * (cartItem.Width + 10);
            int yOffset = rowIndex * (cartItem.Height + 10);

            cartItem.Location = new Point(20 + xOffset, 30 + yOffset);

            // panel5에 UC_CartItem 컨트롤 추가
            panel1.Controls.Add(cartItem);

            // 카트 아이템이 추가될 때마다 총 금액 업데이트
            UpdateTotalAmount();

            // UC_CartItem의 QuantityChangedEvent에 이벤트 핸들러 등록
            cartItem.QuantityChangedEvent += CartItem_QuantityChanged;
        }

        // UC_CartItem의 수량 변경 이벤트 핸들러
        private void CartItem_QuantityChanged(object sender, EventArgs e)
        {
            // 총 금액 업데이트
            UpdateTotalAmount();
        }

        // 총 금액을 업데이트하는 메서드
        // 총 금액을 업데이트하는 메서드
        public void UpdateTotalAmount(double decreaseAmount = 0)
        {
            // panel5에 있는 모든 UC_CartItem의 가격을 합산
            double total = panel1.Controls.OfType<UC_CartItem>().Sum(item => item.CalculateTotalPrice());

            // 현재 총 금액에서 감소값을 빼서 업데이트
            totalAmount = Math.Max(0, total - decreaseAmount);

            // 총 금액을 레이블에 표시
            label3_Amount.Text = totalAmount.ToString("C");
        }

        // UC_CartItem을 패널에서 제거하는 메서드
        public void RemoveCartItemFromPanel(UC_CartItem cartItem)
        {
            // UC_CartItem의 RemoveFromPanelEvent에 이벤트 핸들러 등록
            cartItem.RemoveFromPanelEvent += CartItem_RemoveFromPanel;

            // 패널에서 UC_CartItem 제거
            panel1.Controls.Remove(cartItem);

            // 제거 후의 위치 조정
            AdjustCartItemsPosition(panel1);

            // 총 금액 업데이트 (여기에서는 이미 제거된 상품의 금액을 감소값으로 전달)
            UpdateTotalAmount();
        }

        // UC_CartItem의 삭제 이벤트 핸들러
        private void CartItem_RemoveFromPanel(object sender, EventArgs e)
        {
            // 총 금액이 음수가 되지 않도록 최소값을 0으로 설정
            totalAmount = Math.Max(0, totalAmount);

            // 총 금액 업데이트
            UpdateTotalAmount();
        }

        // Panel 내의 UC_CartItem 위치 조정
        private void AdjustCartItemsPosition(Panel panel)
        {
            int yOffset = 30; // 초기 위치

            // Panel에 있는 모든 UC_CartItem들의 위치를 조정
            foreach (Control control in panel.Controls.OfType<UC_CartItem>())
            {
                control.Location = new Point(20, yOffset);
                yOffset += control.Height + 10; // 간격 조절
            }
        }
        private void button1_Main_Page_Click(object sender, EventArgs e)
        {
            if (UserDataManager.loginUser != null)
            {
                Hide();
                // 메인페이지의 로그인 버튼 텍스트를 로그아웃으로 바꾼다.
                My_Page.isLogin_Button_Send = true;
                new Main_Form().ShowDialog(this);
            }
            else
            {
                Hide() ;
                new Main_Form().ShowDialog(this);
            }
                
        }

        private void button2_User_Information_Click(object sender, EventArgs e)
        {
            if (button2_Login_Click.Text.Equals("로그아웃"))
            {
                Hide();
                My_Page frm3 = new My_Page();
                frm3.ShowDialog();
                if (Withdraw_Check.withdrawCheck == true)
                    button2_Login_Click.Text = "로그인";
            }
            else
                MessageBox.Show("로그인을 해주세요.");
            Show();
        }

        private void button3_Return_Main_Click(object sender, EventArgs e)
        {

            if (UserDataManager.loginUser != null)
            {
                Hide();
                // 메인페이지의 로그인 버튼 텍스트를 로그아웃으로 바꾼다.
                My_Page.isLogin_Button_Send = true;
                new Main_Form().ShowDialog(this);
            }
            else
            {
                Hide();
                new Main_Form().ShowDialog(this);
            }

        }

        private void button4_Purchase_Click(object sender, EventArgs e)
        {
            this.Hide();
            Purchase_Window frm9 = new Purchase_Window();
            foreach (UC_CartItem cartItem in panel1.Controls.OfType<UC_CartItem>())
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
