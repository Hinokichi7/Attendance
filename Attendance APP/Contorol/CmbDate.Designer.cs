namespace Attendance_APP
{
    partial class CmbDate
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_day = new System.Windows.Forms.ComboBox();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(255, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "日";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(172, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "月";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(89, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "年";
            // 
            // cmb_day
            // 
            this.cmb_day.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_day.FormattingEnabled = true;
            this.cmb_day.Location = new System.Drawing.Point(202, 6);
            this.cmb_day.Name = "cmb_day";
            this.cmb_day.Size = new System.Drawing.Size(47, 25);
            this.cmb_day.TabIndex = 2;
            // 
            // cmb_month
            // 
            this.cmb_month.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Location = new System.Drawing.Point(119, 3);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(47, 25);
            this.cmb_month.TabIndex = 3;
            this.cmb_month.SelectedIndexChanged += new System.EventHandler(this.cmb_month_SelectedIndexChanged);
            // 
            // cmb_year
            // 
            this.cmb_year.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Location = new System.Drawing.Point(3, 3);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(80, 25);
            this.cmb_year.TabIndex = 4;
            this.cmb_year.SelectedIndexChanged += new System.EventHandler(this.cmb_year_SelectedIndexChanged);
            // 
            // CmbDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_day);
            this.Controls.Add(this.cmb_month);
            this.Controls.Add(this.cmb_year);
            this.Name = "CmbDate";
            this.Size = new System.Drawing.Size(281, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_day;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.ComboBox cmb_year;
    }
}
