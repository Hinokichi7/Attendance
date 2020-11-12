namespace Attendance_APP.Contorol
{
    partial class CmbStampingType
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_stampingType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmb_stampingType
            // 
            this.cmb_stampingType.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_stampingType.FormattingEnabled = true;
            this.cmb_stampingType.Location = new System.Drawing.Point(3, 3);
            this.cmb_stampingType.Name = "cmb_stampingType";
            this.cmb_stampingType.Size = new System.Drawing.Size(94, 26);
            this.cmb_stampingType.TabIndex = 0;
            this.cmb_stampingType.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // CmbStampingType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_stampingType);
            this.Name = "CmbStampingType";
            this.Size = new System.Drawing.Size(104, 35);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_stampingType;
    }
}
