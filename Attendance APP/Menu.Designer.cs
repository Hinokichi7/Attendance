namespace Attendance_APP
{
    partial class Menu
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Stamping = new System.Windows.Forms.Button();
            this.cmb_employee = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.End = new System.Windows.Forms.Button();
            this.openCsvOutput = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Stamping
            // 
            this.Stamping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Stamping.Font = new System.Drawing.Font("メイリオ", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Stamping.Location = new System.Drawing.Point(3, 59);
            this.Stamping.Name = "Stamping";
            this.Stamping.Size = new System.Drawing.Size(440, 64);
            this.Stamping.TabIndex = 1;
            this.Stamping.Text = "打刻";
            this.Stamping.UseVisualStyleBackColor = true;
            this.Stamping.Click += new System.EventHandler(this.Stamping_Click);
            // 
            // cmb_employee
            // 
            this.cmb_employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_employee.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_employee.FormattingEnabled = true;
            this.cmb_employee.Location = new System.Drawing.Point(3, 3);
            this.cmb_employee.Name = "cmb_employee";
            this.cmb_employee.Size = new System.Drawing.Size(440, 49);
            this.cmb_employee.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cmb_employee, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Stamping, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.End, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.openCsvOutput, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 255);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // End
            // 
            this.End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.End.Font = new System.Drawing.Font("メイリオ", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.End.Location = new System.Drawing.Point(3, 129);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(440, 62);
            this.End.TabIndex = 5;
            this.End.Text = "終了";
            this.End.UseVisualStyleBackColor = true;
            this.End.Click += new System.EventHandler(this.End_Click);
            // 
            // openCsvOutput
            // 
            this.openCsvOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openCsvOutput.Font = new System.Drawing.Font("メイリオ", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.openCsvOutput.Location = new System.Drawing.Point(3, 197);
            this.openCsvOutput.Name = "openCsvOutput";
            this.openCsvOutput.Size = new System.Drawing.Size(440, 55);
            this.openCsvOutput.TabIndex = 6;
            this.openCsvOutput.Text = "CSV出力";
            this.openCsvOutput.UseVisualStyleBackColor = true;
            this.openCsvOutput.Click += new System.EventHandler(this.outputCsv_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 255);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Menu";
            this.Text = "勤怠ソフト";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Stamping;
        private System.Windows.Forms.ComboBox cmb_employee;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button End;
        private System.Windows.Forms.Button openCsvOutput;
    }
}

