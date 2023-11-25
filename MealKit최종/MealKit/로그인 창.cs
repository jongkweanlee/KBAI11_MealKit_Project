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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            메인화면 frm1 = new 메인화면();
            frm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            회원가입 frm10 = new 회원가입();
            frm10.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
