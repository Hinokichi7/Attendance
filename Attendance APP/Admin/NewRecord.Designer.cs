namespace Attendance_APP
{
    partial class NewRecord
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
            this.cmb_employee = new System.Windows.Forms.ComboBox();
            this.departmentName = new System.Windows.Forms.Label();
            this.cmb_year = new System.Windows.Forms.ComboBox();
            this.cmb_month = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_day = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_startHour = new System.Windows.Forms.ComboBox();
            this.cmb_startMinut = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_endHour = new System.Windows.Forms.ComboBox();
            this.cmb_endMinut = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AddNewRecord = new System.Windows.Forms.Button();
            this.cmb_stampingType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.remark = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmb_employee
            // 
            this.cmb_employee.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_employee.FormattingEnabled = true;
            this.cmb_employee.Location = new System.Drawing.Point(101, 25);
            this.cmb_employee.Name = "cmb_employee";
            this.cmb_employee.Size = new System.Drawing.Size(120, 32);
            this.cmb_employee.TabIndex = 0;
            this.cmb_employee.SelectionChangeCommitted += new System.EventHandler(this.cmb_employee_SelectionChangeCommitted_1);
            // 
            // departmentName
            // 
            this.departmentName.AutoSize = true;
            this.departmentName.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.departmentName.Location = new System.Drawing.Point(106, 71);
            this.departmentName.Name = "departmentName";
            this.departmentName.Size = new System.Drawing.Size(58, 24);
            this.departmentName.TabIndex = 1;
            this.departmentName.Text = "部署名";
            // 
            // cmb_year
            // 
            this.cmb_year.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_year.FormattingEnabled = true;
            this.cmb_year.Location = new System.Drawing.Point(101, 98);
            this.cmb_year.Name = "cmb_year";
            this.cmb_year.Size = new System.Drawing.Size(80, 25);
            this.cmb_year.TabIndex = 0;
            this.cmb_year.SelectedIndexChanged += new System.EventHandler(this.cmb_year_SelectedIndexChanged_1);
            // 
            // cmb_month
            // 
            this.cmb_month.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_month.FormattingEnabled = true;
            this.cmb_month.Location = new System.Drawing.Point(217, 98);
            this.cmb_month.Name = "cmb_month";
            this.cmb_month.Size = new System.Drawing.Size(47, 25);
            this.cmb_month.TabIndex = 0;
            this.cmb_month.SelectedIndexChanged += new System.EventHandler(this.cmb_month_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(187, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "年";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(270, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "月";
            // 
            // cmb_day
            // 
            this.cmb_day.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_day.FormattingEnabled = true;
            this.cmb_day.Location = new System.Drawing.Point(300, 98);
            this.cmb_day.Name = "cmb_day";
            this.cmb_day.Size = new System.Drawing.Size(47, 25);
            this.cmb_day.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(353, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "日";
            // 
            // cmb_startHour
            // 
            this.cmb_startHour.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_startHour.FormattingEnabled = true;
            this.cmb_startHour.Location = new System.Drawing.Point(101, 189);
            this.cmb_startHour.Name = "cmb_startHour";
            this.cmb_startHour.Size = new System.Drawing.Size(45, 25);
            this.cmb_startHour.TabIndex = 0;
            // 
            // cmb_startMinut
            // 
            this.cmb_startMinut.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_startMinut.FormattingEnabled = true;
            this.cmb_startMinut.Location = new System.Drawing.Point(174, 189);
            this.cmb_startMinut.Name = "cmb_startMinut";
            this.cmb_startMinut.Size = new System.Drawing.Size(45, 25);
            this.cmb_startMinut.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(152, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(225, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "～";
            // 
            // cmb_endHour
            // 
            this.cmb_endHour.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_endHour.FormattingEnabled = true;
            this.cmb_endHour.Location = new System.Drawing.Point(259, 189);
            this.cmb_endHour.Name = "cmb_endHour";
            this.cmb_endHour.Size = new System.Drawing.Size(45, 25);
            this.cmb_endHour.TabIndex = 0;
            // 
            // cmb_endMinut
            // 
            this.cmb_endMinut.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_endMinut.FormattingEnabled = true;
            this.cmb_endMinut.Location = new System.Drawing.Point(332, 189);
            this.cmb_endMinut.Name = "cmb_endMinut";
            this.cmb_endMinut.Size = new System.Drawing.Size(45, 25);
            this.cmb_endMinut.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(310, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = ":";
            // 
            // AddNewRecord
            // 
            this.AddNewRecord.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AddNewRecord.Location = new System.Drawing.Point(151, 279);
            this.AddNewRecord.Name = "AddNewRecord";
            this.AddNewRecord.Size = new System.Drawing.Size(123, 32);
            this.AddNewRecord.TabIndex = 2;
            this.AddNewRecord.Text = "新規打刻";
            this.AddNewRecord.UseVisualStyleBackColor = true;
            this.AddNewRecord.Click += new System.EventHandler(this.AddNewRecord_Click_1);
            // 
            // cmb_stampingType
            // 
            this.cmb_stampingType.Font = new System.Drawing.Font("メイリオ", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmb_stampingType.FormattingEnabled = true;
            this.cmb_stampingType.Location = new System.Drawing.Point(101, 145);
            this.cmb_stampingType.Name = "cmb_stampingType";
            this.cmb_stampingType.Size = new System.Drawing.Size(80, 25);
            this.cmb_stampingType.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(24, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "氏名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(24, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "部署名";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(24, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 24);
            this.label9.TabIndex = 1;
            this.label9.Text = "年月日";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(24, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 24);
            this.label10.TabIndex = 1;
            this.label10.Text = "勤務種別";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(24, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 24);
            this.label11.TabIndex = 1;
            this.label11.Text = "時間";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(24, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 24);
            this.label12.TabIndex = 1;
            this.label12.Text = "備考";
            // 
            // remark
            // 
            this.remark.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.remark.Location = new System.Drawing.Point(101, 236);
            this.remark.Name = "remark";
            this.remark.Size = new System.Drawing.Size(276, 25);
            this.remark.TabIndex = 4;
            // 
            // NewRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 345);
            this.Controls.Add(this.remark);
            this.Controls.Add(this.cmb_stampingType);
            this.Controls.Add(this.AddNewRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.departmentName);
            this.Controls.Add(this.cmb_day);
            this.Controls.Add(this.cmb_endMinut);
            this.Controls.Add(this.cmb_endHour);
            this.Controls.Add(this.cmb_startMinut);
            this.Controls.Add(this.cmb_startHour);
            this.Controls.Add(this.cmb_month);
            this.Controls.Add(this.cmb_year);
            this.Controls.Add(this.cmb_employee);
            this.Name = "NewRecord";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_employee;
        private System.Windows.Forms.Label departmentName;
        private System.Windows.Forms.ComboBox cmb_year;
        private System.Windows.Forms.ComboBox cmb_month;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_day;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_startHour;
        private System.Windows.Forms.ComboBox cmb_startMinut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_endHour;
        private System.Windows.Forms.ComboBox cmb_endMinut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddNewRecord;
        private System.Windows.Forms.ComboBox cmb_stampingType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox remark;
    }
}