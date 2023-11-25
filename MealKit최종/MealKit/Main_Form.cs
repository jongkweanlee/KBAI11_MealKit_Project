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
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            label1_Event.Text = "신규 가입 회원 이벤트";
            label2_Discount_Rate.Text = "30%";
            label3_Current_Rate.Text = "할인 중";
            label4_Current_Rate_Days.Text = "11월 9일 ~ 11월 27일 까지";
            label5_Western_Food.Text = "양식";
            label6_Korean_Food.Text = "한식";
            label7_China_Food.Text = "중식";
            label8_Japanese_Food.Text = "일식";          
            //label14_User_ID.Text = "회원명 : ";
            //label15_User_Grade.Text = "등급 : ";
            //label16_User_Earned_Points.Text = "적립 포인트 : ";          

            if (UserDataManager.loginUser != null)
            {
                button2_Login_Click.Text = "로그아웃";
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Advertisement pictureShow = new Advertisement();
            pictureShow.Picture = this.pictureBox1.Image;
            pictureShow.Show();
        }

        private void panel14_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.kb.or.kr/");
        }

        private void button1_CreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Create_Account frm = new Create_Account();
            frm.ShowDialog();
        }

        private void button13_Program_End_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }





        private void button2_Login_Click_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(button2_Login_Click.Text) && button2_Login_Click.Text.Equals("로그인"))
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
            else if (!string.IsNullOrEmpty(button2_Login_Click.Text))
            {
                string ID = UserDataManager.loginUser?.ID; // null 조건부 연산자를 사용하여 null 체크
                string PW = UserDataManager.loginUser?.Password; // null 조건부 연산자를 사용하여 null 체크

                UserDataManager.loginUser = null;
                (sender as Button).Text = "로그인";
                LoginLogoutButtonCheck(ID, PW, "로그아웃");
            }
            else
            {
                // 예외 상황에 대한 처리를 추가할 수 있습니다.
                Console.WriteLine("버튼 텍스트가 null 또는 비어 있습니다.");
            }
        }
        // 로그인, 로그아웃 체크
        public void LoginLogoutButtonCheck(string id, string pw, string txt)
        {
            UserDataManager.Save(id, pw, txt);
        }

        private void button3_Serach_Item_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Search_Results().ShowDialog();
        } 

        private void button4_Item_Basket_Click(object sender, EventArgs e)
        {
            if (UserDataManager.loginUser != null)
            {
                Hide();
                // 메인페이지의 로그인 버튼 텍스트를 로그아웃으로 바꾼다.
                My_Page.isLogin_Button_Send = true;
                new Item_Basket().ShowDialog(this);
            }
            else
            {
                Hide();
                new Item_Basket().ShowDialog(this);
            }        
        }

        private void button5_My_Page_Click(object sender, EventArgs e)
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
            //Show();


        }

        private void button6_Western_Food_Click(object sender, EventArgs e)
        {
            if (UserDataManager.loginUser != null)
            {
                Hide();
                // 메인페이지의 로그인 버튼 텍스트를 로그아웃으로 바꾼다.
                My_Page.isLogin_Button_Send = true;
                new Western_Food().ShowDialog(this);
            }
            else
            {
                Hide();
                new Western_Food().ShowDialog(this);
            }
        }

        private void button7_Korean_Food_Click(object sender, EventArgs e)
        {
            if (UserDataManager.loginUser != null)
            {
                Hide();
                // 메인페이지의 로그인 버튼 텍스트를 로그아웃으로 바꾼다.
                My_Page.isLogin_Button_Send = true;
                new Korean_Food().ShowDialog(this);
            }
            else
            {
                Hide();
                new Korean_Food().ShowDialog(this);
            }
        }

        private void button8_China_Food_Click(object sender, EventArgs e)
        {
            if (UserDataManager.loginUser != null)
            {
                Hide();
                // 메인페이지의 로그인 버튼 텍스트를 로그아웃으로 바꾼다.
                My_Page.isLogin_Button_Send = true;
                new China_Food().ShowDialog(this);
            }
            else
            {
                Hide();
                new China_Food().ShowDialog(this);
            }
        }

        private void button9_Japanese_Food_Click(object sender, EventArgs e)
        {
            if (UserDataManager.loginUser != null)
            {
                Hide();
                // 메인페이지의 로그인 버튼 텍스트를 로그아웃으로 바꾼다.
                My_Page.isLogin_Button_Send = true;
                new Japanese_Food().ShowDialog(this);
            }
            else
            {
                Hide();
                new Japanese_Food().ShowDialog(this);
            }
        }

        private void button1_Purchase_History_Click(object sender, EventArgs e)
        {
            if (button2_Login_Click.Text.Equals("로그아웃"))
            {
                Hide();
                new Purchase_History().ShowDialog();
                if (Withdraw_Check.withdrawCheck == true)
                    button2_Login_Click.Text = "로그인";
            }
            else
                MessageBox.Show("로그인을 해주세요.");
            //Show();
        }
    }
}
