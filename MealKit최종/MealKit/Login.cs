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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Login_Click(object sender, EventArgs e)
        {
            if (textBox1_ID.Text.Trim() == "")
                MessageBox.Show("ID를 입력하세요.");
            else if (textBox2_PW.Text.Trim() == "")
                MessageBox.Show("비밀번호를 입력하세요.");
            else
            {
                try
                {
                    string contents = "";
                    UserInformation user = new UserInformation();
                    user.ID = textBox1_ID.Text;
                    user.Password = textBox2_PW.Text;
                    user.CurrentState = "로그인";
                    UserDataManager.Save(textBox1_ID.Text, textBox2_PW.Text, "로그인", out contents);
                    writeLog(contents);
                    Close();
                }
                catch (Exception) { }
            }
        }

        public void writeLog(string contents)
        {
            string log =
                $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}]";
            log += contents;
            UserDataManager.CurrentStateLog(log);
        }

        private void button2_Return_Main_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main_Form().ShowDialog();
        }

        private void textBox2_PW_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//엔터 키 누르고 다시 올라올 때
                Button1_Login.PerformClick(); //클릭 강제 호출
        }
    }
}
