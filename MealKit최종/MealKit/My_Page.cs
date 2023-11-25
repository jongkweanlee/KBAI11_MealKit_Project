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
    public partial class My_Page : Form
    {
        public static bool isLogin_Button_Send = false;
        public My_Page()
        {
            InitializeComponent();
            if (UserDataManager.loginUser != null)
            {
                label6_ID.Text = UserDataManager.loginUser.ID;
                label3_User_ID.Text = UserDataManager.loginUser.Name;
                label8_PW.Text = UserDataManager.loginUser.Password;
                label10_Phone_Number.Text = UserDataManager.loginUser.PhoneNumber;

                label13_Recipient.Text = UserDataManager.loginUser.Name; // 수령인
                label15_Zipcode.Text = UserDataManager.loginUser.ZipCode;
                label16_Address.Text = UserDataManager.loginUser.Address;
                label17_Detail_Address.Text=UserDataManager.loginUser.DetailAddress;
                label18_Reference_Address.Text = UserDataManager.loginUser.ReferenceAddress;
                label20_Phone_Number.Text=UserDataManager.loginUser.PhoneNumber;
            }
        }

        private void button1_Main_Page_Click(object sender, EventArgs e)
        {
           
            if (UserDataManager.loginUser != null)
            {
                Hide();
                // 메인페이지의 로그인 버튼 텍스트를 로그아웃으로 바꾼다.
                isLogin_Button_Send =true;
                //this.Hide();
                //new

            }
            new Main_Form().ShowDialog(this);
            //frm1.Show();
        }

        private void button2_Item_Basket_Click(object sender, EventArgs e)
        {
            if (UserDataManager.loginUser != null)
            {
                Hide();
                isLogin_Button_Send = true;


            }
            new Item_Basket().ShowDialog();
            
        }

        private void button3_Return_Main_Click(object sender, EventArgs e)
        {
            if (UserDataManager.loginUser != null)
            {
                Hide();
                // 메인페이지의 로그인 버튼 텍스트를 로그아웃으로 바꾼다.
                isLogin_Button_Send = true;
                //this.Hide();
                //new

            }
            new Main_Form().ShowDialog(this);
        }

        private void button4_Withdraw_Click(object sender, EventArgs e)
        {
            MessageBox.Show("예) 클릭 시 해당 유저의 모든 정보가 삭제 됩니다.");
            Withdraw_Check form = new Withdraw_Check();
            form.ShowDialog();
            if (Withdraw_Check.withdrawCheck == true)
                this.Close();
        }
    }
}
