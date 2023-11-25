using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MealKit
{
    public partial class Purchase_Window : Form
    {
        private double totalAmount = 0; // 총 금액을 저장할 변수
        private int containItemCnt = 0;
        private int payment = 0;
        private List<string> itemNames = new List<string>();

        public Purchase_Window()
        {
            InitializeComponent();
            label1_Payment.Text = "최종 결재 금액 : ";
            label2_Amount.Text = "0";
            label1_Purchase_Window.Text = "구매창";
            button5_Purchase.Text = "구매 확인";

            // 폼이 로드될 때 총 금액 업데이트
            UpdateTotalAmount();

            // 로그인 시 배송 정보
            if (UserDataManager.loginUser != null)
            {
                label4_Recipient.Text = UserDataManager.loginUser.Name; // 수령인
                label5_Zipcode.Text = UserDataManager.loginUser.ZipCode;
                label6_Address.Text = UserDataManager.loginUser.Address;
                label7_Detail_Address.Text = UserDataManager.loginUser.DetailAddress;
                label8_Reference_Address.Text = UserDataManager.loginUser.ReferenceAddress;
                label10_Phone_Number.Text = UserDataManager.loginUser.PhoneNumber;

            }

            if (UserDataManager.loginUser != null)
            {               
                panel8.Show();
            }
            else
            {
                panel8.Dispose();
            }
        }

        public void AddCartItemToPanel(UC_CartItem cartItem)
        {
            // 위치 계산
            int itemCount = panel5.Controls.OfType<UC_CartItem>().Count();
            int rowIndex = itemCount / 3;
            int colIndex = itemCount % 3;

            int xOffset = colIndex * (cartItem.Width + 10);
            int yOffset = rowIndex * (cartItem.Height + 10);

            cartItem.Location = new Point(20 + xOffset, 30 + yOffset);

            // panel5에 UC_CartItem 컨트롤 추가
            panel5.Controls.Add(cartItem);

            // 카트 아이템이 추가될 때마다 총 금액 업데이트
            UpdateTotalAmount();

            // UC_CartItem의 QuantityChangedEvent에 이벤트 핸들러 등록
            cartItem.QuantityChangedEvent += CartItem_QuantityChanged;
            containItemCnt += cartItem.Quantity;

            itemNames.Remove(cartItem.itemName);
            itemNames.Add(cartItem.itemName);
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
            double total = panel5.Controls.OfType<UC_CartItem>().Sum(item => item.CalculateTotalPrice());

            // 현재 총 금액에서 감소값을 빼서 업데이트
            totalAmount = Math.Max(0, total - decreaseAmount);
            payment = (int)totalAmount;

            // 총 금액을 레이블에 표시
            label2_Amount.Text = totalAmount.ToString("C");
        }

        // UC_CartItem을 패널에서 제거하는 메서드
        public void RemoveCartItemFromPanel(UC_CartItem cartItem)
        {
            // UC_CartItem의 RemoveFromPanelEvent에 이벤트 핸들러 등록
            cartItem.RemoveFromPanelEvent += CartItem_RemoveFromPanel;

            // 패널에서 UC_CartItem 제거
            panel5.Controls.Remove(cartItem);

            // 제거 후의 위치 조정
            AdjustCartItemsPosition(panel5);

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
                Hide();
                new Main_Form().ShowDialog(this);
            }
        }

        private void button2_Item_Basket_Click(object sender, EventArgs e)
        {
            this.Hide();
            Item_Basket frm3 = new Item_Basket();
            frm3.Show();
        }

        private void button3_User_Information_Click(object sender, EventArgs e)
        {
            this.Hide();
            My_Page frm3 = new My_Page();
            frm3.Show();
        }

        private void button4_Return_Main_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form frm1 = new Main_Form();
            frm1.Show();
        }

        private void button5_Purchase_Click(object sender, EventArgs e)
        {
            if (UserDataManager.loginUser != null)
            {
                this.Hide();

                // 구매하기 버튼 클릭 시 구매 내역 정보 DB로 저장
                string id = UserDataManager.loginUser.ID;
                string name = UserDataManager.loginUser.Name;
                //string cnt = nullCache.count

                //MessageBox.Show(String.Join(", ", itemNames.ToArray()));
                // 구매 내역 DB에 저장
                HistoryData.Save(id, name, String.Join(", ", itemNames.ToArray()), containItemCnt, payment);

                Order_Complete frm3 = new Order_Complete();
                frm3.Show();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
            }
        }
    }
}
