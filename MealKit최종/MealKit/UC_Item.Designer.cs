namespace MealKit
{
    partial class UC_Item
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
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.imgItem = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(3, 9);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(60, 12);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "item Name";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Location = new System.Drawing.Point(119, 9);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(23, 12);
            this.lblItemPrice.TabIndex = 2;
            this.lblItemPrice.Text = "\\0";
            // 
            // imgItem
            // 
            this.imgItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgItem.Location = new System.Drawing.Point(0, 0);
            this.imgItem.Name = "imgItem";
            this.imgItem.Size = new System.Drawing.Size(175, 174);
            this.imgItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgItem.TabIndex = 0;
            this.imgItem.TabStop = false;
            this.imgItem.Click += new System.EventHandler(this.imgItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Controls.Add(this.lblItemName);
            this.panel1.Controls.Add(this.lblItemPrice);
            this.panel1.Location = new System.Drawing.Point(0, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 31);
            this.panel1.TabIndex = 3;
            // 
            // UC_Item
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imgItem);
            this.Font = new System.Drawing.Font("경기천년제목 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "UC_Item";
            this.Size = new System.Drawing.Size(175, 174);
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgItem;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Panel panel1;
    }
}
