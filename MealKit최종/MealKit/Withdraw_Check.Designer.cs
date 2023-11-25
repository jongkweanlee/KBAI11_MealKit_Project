namespace MealKit
{
    partial class Withdraw_Check
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Withdraw_Check));
            this.button2_No = new System.Windows.Forms.Button();
            this.button1_Yes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2_No
            // 
            this.button2_No.BackColor = System.Drawing.Color.SeaGreen;
            this.button2_No.FlatAppearance.BorderSize = 0;
            this.button2_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2_No.ForeColor = System.Drawing.Color.Beige;
            this.button2_No.Location = new System.Drawing.Point(190, 65);
            this.button2_No.Name = "button2_No";
            this.button2_No.Size = new System.Drawing.Size(75, 23);
            this.button2_No.TabIndex = 3;
            this.button2_No.Text = "아니오";
            this.button2_No.UseVisualStyleBackColor = false;
            this.button2_No.Click += new System.EventHandler(this.button2_No_Click);
            // 
            // button1_Yes
            // 
            this.button1_Yes.BackColor = System.Drawing.Color.SeaGreen;
            this.button1_Yes.FlatAppearance.BorderSize = 0;
            this.button1_Yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1_Yes.ForeColor = System.Drawing.Color.Beige;
            this.button1_Yes.Location = new System.Drawing.Point(76, 65);
            this.button1_Yes.Name = "button1_Yes";
            this.button1_Yes.Size = new System.Drawing.Size(75, 23);
            this.button1_Yes.TabIndex = 2;
            this.button1_Yes.Text = "예";
            this.button1_Yes.UseVisualStyleBackColor = false;
            this.button1_Yes.Click += new System.EventHandler(this.button1_Yes_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaGreen;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-5, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 182);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Beige;
            this.panel2.Controls.Add(this.button1_Yes);
            this.panel2.Controls.Add(this.button2_No);
            this.panel2.Location = new System.Drawing.Point(17, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 152);
            this.panel2.TabIndex = 4;
            // 
            // Withdraw_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 176);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.SeaGreen;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Withdraw_Check";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "회원탈퇴";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2_No;
        private System.Windows.Forms.Button button1_Yes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}