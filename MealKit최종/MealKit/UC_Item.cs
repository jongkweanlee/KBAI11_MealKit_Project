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
    public partial class UC_Item : UserControl
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

        public UC_Item()
        {
            InitializeComponent();
        }

        public event EventHandler ItemClicked; // 클릭 이벤트를 위한 이벤트 정의
        private void imgItem_Click(object sender, EventArgs e)
        {
            // 클릭 이벤트가 등록되어 있다면 호출
            ItemClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
