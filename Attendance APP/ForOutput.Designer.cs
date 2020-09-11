namespace Attendance_APP
{
    partial class ForOutput
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
            this.outputCsv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_startYear = new System.Windows.Forms.ComboBox();
            this.cmb_startMonth = new System.Windows.Forms.ComboBox();
            this.cmb_startDay = new System.Windows.Forms.ComboBox();
            this.cmb_endYear = new System.Windows.Forms.ComboBox();
            this.cmb_endMonth = new System.Windows.Forms.ComboBox();
            this.cmb_endDay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputCsv
            // 
            this.outputCsv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outputCsv.Font = new System.Drawing.Font("メイリオ", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.outputCsv.Location = new System.Drawing.Point(0, 193);
            this.outputCsv.Name = "outputCsv";
            this.outputCsv.Size = new System.Drawing.Size(446, 62);
            this.outputCsv.TabIndex = 0;
            this.outputCsv.Text = "出力";
            this.outputCsv.UseVisualStyleBackColor = true;
            this.outputCsv.Click += new System.EventHandler(this.outputCsv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "期間指定";
            // 
            // cmb_startYear
            // 
            this.cmb_startYear.FormattingEnabled = true;
            this.cmb_startYear.Location = new System.Drawing.Point(29, 82);
            this.cmb_startYear.Name = "cmb_startYear";
            this.cmb_startYear.Size = new System.Drawing.Size(60, 20);
            this.cmb_startYear.TabIndex = 3;
            this.cmb_startYear.SelectedIndexChanged += new System.EventHandler(this.cmb_startYear_SelectedIndexChanged);
            // 
            // cmb_startMonth
            // 
            this.cmb_startMonth.FormattingEnabled = true;
            this.cmb_startMonth.Location = new System.Drawing.Point(95, 82);
            this.cmb_startMonth.Name = "cmb_startMonth";
            this.cmb_startMonth.Size = new System.Drawing.Size(45, 20);
            this.cmb_startMonth.TabIndex = 4;
            this.cmb_startMonth.SelectedIndexChanged += new System.EventHandler(this.cmb_startMonth_SelectedIndexChanged);
            // 
            // cmb_startDay
            // 
            this.cmb_startDay.FormattingEnabled = true;
            this.cmb_startDay.Location = new System.Drawing.Point(146, 82);
            this.cmb_startDay.Name = "cmb_startDay";
            this.cmb_startDay.Size = new System.Drawing.Size(45, 20);
            this.cmb_startDay.TabIndex = 5;
            // 
            // cmb_endYear
            // 
            this.cmb_endYear.FormattingEnabled = true;
            this.cmb_endYear.Location = new System.Drawing.Point(219, 82);
            this.cmb_endYear.Name = "cmb_endYear";
            this.cmb_endYear.Size = new System.Drawing.Size(60, 20);
            this.cmb_endYear.TabIndex = 6;
            this.cmb_endYear.SelectedIndexChanged += new System.EventHandler(this.cmb_endYear_SelectedIndexChanged);
            // 
            // cmb_endMonth
            // 
            this.cmb_endMonth.FormattingEnabled = true;
            this.cmb_endMonth.Location = new System.Drawing.Point(285, 82);
            this.cmb_endMonth.Name = "cmb_endMonth";
            this.cmb_endMonth.Size = new System.Drawing.Size(45, 20);
            this.cmb_endMonth.TabIndex = 7;
            this.cmb_endMonth.SelectedIndexChanged += new System.EventHandler(this.cmb_emdMonth_SelectedIndexChanged);
            // 
            // cmb_endDay
            // 
            this.cmb_endDay.FormattingEnabled = true;
            this.cmb_endDay.Location = new System.Drawing.Point(336, 82);
            this.cmb_endDay.Name = "cmb_endDay";
            this.cmb_endDay.Size = new System.Drawing.Size(45, 20);
            this.cmb_endDay.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(197, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "-";
            // 
            // ForOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 255);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_endDay);
            this.Controls.Add(this.cmb_endMonth);
            this.Controls.Add(this.cmb_endYear);
            this.Controls.Add(this.cmb_startDay);
            this.Controls.Add(this.cmb_startMonth);
            this.Controls.Add(this.cmb_startYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputCsv);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ForOutput";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button outputCsv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_startYear;
        private System.Windows.Forms.ComboBox cmb_startMonth;
        private System.Windows.Forms.ComboBox cmb_startDay;
        private System.Windows.Forms.ComboBox cmb_endYear;
        private System.Windows.Forms.ComboBox cmb_endMonth;
        private System.Windows.Forms.ComboBox cmb_endDay;
        private System.Windows.Forms.Label label2;
    }
}