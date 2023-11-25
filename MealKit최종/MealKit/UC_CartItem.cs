using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealKit
{
    public partial class UC_CartItem : UserControl
    {
        public Image itemImage
        {
            get { return imgItem.Image; }
            set { imgItem.Image = value; }
        }
        public string itemName
        {
            get { return lblItemName.Text; }
            set { lblItemName.Text = value; }
        }
        public string itemPrice
        {
            get { return lblItemPrice.Text; }
            set { lblItemPrice.Text = value; }
        }
        private int quantity; // 상품 수량
        decimal unitPrice; // 상품 단가

        public UC_CartItem()
        {
            InitializeComponent();
            // 클릭 이벤트 핸들러 등록
            button13.Click += button13_Click;
        }

        // 총 가격을 업데이트하는 메서드
        private void UpdateTotalPrice()
        {
            unitPrice = decimal.Parse(new string(itemPrice.Where(c => Char.IsDigit(c) || c == '.').ToArray()));
            decimal totalPrice = Quantity * unitPrice;
            label2.Text = $"{totalPrice:C}";
        }
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
        // 추가된 이벤트
        // public event EventHandler RemoveFromPanelEvent;
        // 추가된 이벤트 핸들러를 호출하는 메서드

        // 상품이 삭제될 때 호출되는 메서드
        protected virtual void OnRemoveFromPanel()
        {
            RemoveFromPanelEvent?.Invoke(this, EventArgs.Empty);

            // 참조된 부모 폼의 메서드 호출 (총 금액 업데이트를 요청)
            if (ParentForm is Purchase_Window parentForm)
            {
                // 현재 상품의 금액을 부모 폼에 전달하여 총 금액 감소
                parentForm.UpdateTotalAmount(-CalculateTotalPrice());
            }
        }

        // 상품의 총 가격 계산 메서드
        public double CalculateTotalPrice()
        {
            return Quantity * double.Parse(new string(itemPrice.Where(c => char.IsDigit(c) || c == '.').ToArray()));
        }

        public event EventHandler RemoveFromPanelEvent;

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                label1.Text = quantity.ToString();
                UpdateTotalPrice();
            }
        }

        // 상품 수량이 변경될 때 호출되는 메서드
        protected virtual void OnQuantityChanged()
        {
            QuantityChangedEvent?.Invoke(this, EventArgs.Empty);
            // 참조된 부모 폼의 메서드 호출 (총 금액 업데이트를 요청)
            if (ParentForm is Purchase_Window parentForm)
            {
                parentForm.UpdateTotalAmount();
            }
        }

        public event EventHandler QuantityChangedEvent;
        private void button1_Click(object sender, EventArgs e)
        {
            // 상품 수량 증가
            quantity++;
            string total = quantity.ToString();
            label1.Text = total;
            // 상품 가격을 숫자로 변환하여 곱셈
            unitPrice = decimal.Parse(new string(itemPrice.Where(c => Char.IsDigit(c) || c == '.').ToArray()));
            // 총 가격 계산 및 표시
            decimal totalPrice = quantity * unitPrice;
            label2.Text = $"{totalPrice:C}";
            // 상품 수량이 변경되면 부모 폼의 총 금액 업데이트
            OnQuantityChanged();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 상품 수량 증가
            if (quantity > 1)
            {
                quantity--;
                string total = quantity.ToString();
                label1.Text = total;
                // 상품 가격을 숫자로 변환하여 곱셈
                unitPrice = decimal.Parse(new string(itemPrice.Where(c => Char.IsDigit(c) || c == '.').ToArray()));
                // 총 가격 계산 및 표시
                decimal totalPrice = quantity * unitPrice;
                label2.Text = $"{totalPrice:C}";
                // 상품 수량이 변경되면 부모 폼의 총 금액 업데이트
                OnQuantityChanged();
            }
        }
        
        private void button13_Click(object sender, EventArgs e)
        {
            // 현재 컨트롤이 UC_CartItem이 아니면 종료
            if (!(this.Parent is Panel parentPanel) || parentPanel.Name != "panel5")
            {
                return;
            }

            // 부모 패널에서 현재 UC_CartItem 제거
            parentPanel.Controls.Remove(this);

            // 제거된 후의 위치 조정
            AdjustCartItemsPosition(parentPanel);

            // 부모 컨트롤로 이벤트 발생을 알림
            OnRemoveFromPanel();
        }
        
    }
}
