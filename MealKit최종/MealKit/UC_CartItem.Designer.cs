namespace MealKit
{
    partial class UC_CartItem
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_CartItem));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblItemName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.imgItem = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.lblItemPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 30;
            this.bunifuElipse2.TargetControl = this;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("경기천년제목 Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemName.Location = new System.Drawing.Point(107, 29);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(77, 15);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "item Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("경기천년제목 Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(149, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "1";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(186, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = " ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(110, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = " ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imgItem
            // 
            this.imgItem.BackColor = System.Drawing.Color.Silver;
            this.imgItem.Location = new System.Drawing.Point(12, 14);
            this.imgItem.Name = "imgItem";
            this.imgItem.Size = new System.Drawing.Size(85, 77);
            this.imgItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgItem.TabIndex = 0;
            this.imgItem.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("경기천년바탕 Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(208, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 7;
            // 
            // button13
            // 
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.Location = new System.Drawing.Point(12, 14);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(29, 23);
            this.button13.TabIndex = 16;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblItemPrice.Font = new System.Drawing.Font("경기천년제목 Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemPrice.Location = new System.Drawing.Point(12, 79);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(24, 12);
            this.lblItemPrice.TabIndex = 3;
            this.lblItemPrice.Text = "\\0";
            // 
            // UC_CartItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.button13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.imgItem);
            this.Font = new System.Drawing.Font("경기천년제목 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "UC_CartItem";
            this.Size = new System.Drawing.Size(306, 106);
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.PictureBox imgItem;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label lblItemPrice;
    }
}
