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
    public partial class Purchase_History : Form
    {
        public Purchase_History()
        {
            InitializeComponent();
            label1_Purchase_History.Text = "구매 내역";
            // 로그인 시 배송 정보
            if (UserDataManager.loginUser != null)
            {
                label4_Recipient.Text = UserDataManager.loginUser.Name; // 수령인
                label5_Zipcode.Text = UserDataManager.loginUser.ZipCode;
                label6_Address.Text = UserDataManager.loginUser.Address;
                label7_Detail_Address.Text = UserDataManager.loginUser.DetailAddress;
                label8_Reference_Address.Text = UserDataManager.loginUser.ReferenceAddress;
                label10_Phone_Number.Text = UserDataManager.loginUser.PhoneNumber;

                label1.Text = UserDataManager.loginUser.ID;
                label2.Text = "";
                HistoryData.HistoryLoad(label1.Text);
                foreach (var item in HistoryData.purchaseUsers)
                {
                    label2.Text += item.ToString() + Environment.NewLine;
                }


                //label2.Text = HistoryData.purchaseUser.Item_Name;
            }
        }

        private void button4_Return_Main_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form frm1 = new Main_Form();
            frm1.Show();
        }

        private void button1_Main_Page_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form frm1 = new Main_Form();
            frm1.Show();
        }

        private void button2_Item_Basket_Click(object sender, EventArgs e)
        {
            this.Hide();
            Item_Basket frm3 = new Item_Basket();
            frm3.Show();
        }
    }
}
