namespace MealKit
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1_ID = new System.Windows.Forms.Label();
            this.textBox1_ID = new System.Windows.Forms.TextBox();
            this.label2_PW = new System.Windows.Forms.Label();
            this.textBox2_PW = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button1_Login = new System.Windows.Forms.Button();
            this.button2_Return_Main = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1_ID
            // 
            this.label1_ID.AutoSize = true;
            this.label1_ID.BackColor = System.Drawing.Color.Beige;
            this.label1_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1_ID.Location = new System.Drawing.Point(232, 179);
            this.label1_ID.Name = "label1_ID";
            this.label1_ID.Size = new System.Drawing.Size(55, 24);
            this.label1_ID.TabIndex = 35;
            this.label1_ID.Text = "아이디";
            // 
            // textBox1_ID
            // 
            this.textBox1_ID.Location = new System.Drawing.Point(316, 177);
            this.textBox1_ID.Name = "textBox1_ID";
            this.textBox1_ID.Size = new System.Drawing.Size(165, 21);
            this.textBox1_ID.TabIndex = 34;
            // 
            // label2_PW
            // 
            this.label2_PW.AutoSize = true;
            this.label2_PW.BackColor = System.Drawing.Color.Beige;
            this.label2_PW.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2_PW.Location = new System.Drawing.Point(232, 218);
            this.label2_PW.Name = "label2_PW";
            this.label2_PW.Size = new System.Drawing.Size(70, 24);
            this.label2_PW.TabIndex = 36;
            this.label2_PW.Text = "패스워드";
            // 
            // textBox2_PW
            // 
            this.textBox2_PW.Location = new System.Drawing.Point(316, 216);
            this.textBox2_PW.Name = "textBox2_PW";
            this.textBox2_PW.Size = new System.Drawing.Size(165, 21);
            this.textBox2_PW.TabIndex = 37;
            this.textBox2_PW.UseSystemPasswordChar = true;
            this.textBox2_PW.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_PW_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(708, 426);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Button1_Login
            // 
            this.Button1_Login.BackColor = System.Drawing.Color.SeaGreen;
            this.Button1_Login.FlatAppearance.BorderSize = 0;
            this.Button1_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Button1_Login.ForeColor = System.Drawing.Color.White;
            this.Button1_Login.Location = new System.Drawing.Point(316, 258);
            this.Button1_Login.Name = "Button1_Login";
            this.Button1_Login.Size = new System.Drawing.Size(96, 31);
            this.Button1_Login.TabIndex = 44;
            this.Button1_Login.Text = "로그인";
            this.Button1_Login.UseVisualStyleBackColor = false;
            this.Button1_Login.Click += new System.EventHandler(this.Button1_Login_Click);
            // 
            // button2_Return_Main
            // 
            this.button2_Return_Main.FlatAppearance.BorderSize = 0;
            this.button2_Return_Main.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2_Return_Main.Image = ((System.Drawing.Image)(resources.GetObject("button2_Return_Main.Image")));
            this.button2_Return_Main.Location = new System.Drawing.Point(691, 12);
            this.button2_Return_Main.Name = "button2_Return_Main";
            this.button2_Return_Main.Size = new System.Drawing.Size(29, 24);
            this.button2_Return_Main.TabIndex = 45;
            this.button2_Return_Main.UseVisualStyleBackColor = true;
            this.button2_Return_Main.Click += new System.EventHandler(this.button2_Return_Main_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(732, 454);
            this.Controls.Add(this.button2_Return_Main);
            this.Controls.Add(this.Button1_Login);
            this.Controls.Add(this.textBox2_PW);
            this.Controls.Add(this.label2_PW);
            this.Controls.Add(this.label1_ID);
            this.Controls.Add(this.textBox1_ID);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2_PW;
        private System.Windows.Forms.Label label2_PW;
        private System.Windows.Forms.Label label1_ID;
        private System.Windows.Forms.TextBox textBox1_ID;
        private System.Windows.Forms.Button Button1_Login;
        private System.Windows.Forms.Button button2_Return_Main;
    }
}