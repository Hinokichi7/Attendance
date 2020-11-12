namespace Attendance_APP
{
    partial class CmbEmployee
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
            this.cmb_employee = new System.Windows.Forms.ComboBox();
            this.departmentName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_employee
            // 
            this.cmb_employee.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_employee.FormattingEnabled = true;
            this.cmb_employee.Location = new System.Drawing.Point(3, 3);
            this.cmb_employee.Name = "cmb_employee";
            this.cmb_employee.Size = new System.Drawing.Size(100, 31);
            this.cmb_employee.TabIndex = 0;
            this.cmb_employee.SelectionChangeCommitted += new System.EventHandler(this.cmb_employee_SelectionChangeCommitted_1);
            // 
            // departmentName
            // 
            this.departmentName.AutoSize = true;
            this.departmentName.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.departmentName.Location = new System.Drawing.Point(3, 37);
            this.departmentName.Name = "departmentName";
            this.departmentName.Size = new System.Drawing.Size(0, 23);
            this.departmentName.TabIndex = 1;
            // 
            // CmbEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.departmentName);
            this.Controls.Add(this.cmb_employee);
            this.Name = "CmbEmployee";
            this.Size = new System.Drawing.Size(147, 79);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_employee;
        private System.Windows.Forms.Label departmentName;
    }
}
