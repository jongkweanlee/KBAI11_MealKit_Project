namespace MealKit
{
    partial class UC_PayMent
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblItemName = new System.Windows.Forms.Label();
            this.imgItem = new System.Windows.Forms.PictureBox();
            this.lblItemPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("경기천년제목 Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemName.Location = new System.Drawing.Point(192, 9);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(113, 37);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "label1";
            // 
            // imgItem
            // 
            this.imgItem.Location = new System.Drawing.Point(0, 0);
            this.imgItem.Name = "imgItem";
            this.imgItem.Size = new System.Drawing.Size(175, 174);
            this.imgItem.TabIndex = 2;
            this.imgItem.TabStop = false;
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("경기천년제목 Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemPrice.Location = new System.Drawing.Point(192, 83);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(113, 37);
            this.lblItemPrice.TabIndex = 3;
            this.lblItemPrice.Text = "label2";
            // 
            // UC_PayMent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.imgItem);
            this.Controls.Add(this.lblItemName);
            this.Name = "UC_PayMent";
            this.Size = new System.Drawing.Size(811, 177);
            ((System.ComponentModel.ISupportInitialize)(this.imgItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.PictureBox imgItem;
    }
}
