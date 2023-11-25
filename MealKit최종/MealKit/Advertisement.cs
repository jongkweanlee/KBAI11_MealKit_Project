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
    public partial class Advertisement : Form
    {
        public Advertisement()
        {
            InitializeComponent();
        }
        Image picture;
        public Image Picture
        {
            get 
            { 
                return picture; 
            }
            set
            {
                picture = value;
                pictureBox1.Image = picture;
            }
        }
    }
}
