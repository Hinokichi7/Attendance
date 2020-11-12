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
            this.cmbDate1 = new Attendance_APP.CmbDate();
            this.cmbDate2 = new Attendance_APP.CmbDate();
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
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "期間指定";
            // 
            // cmbDate1
            // 
            this.cmbDate1.Location = new System.Drawing.Point(95, 67);
            this.cmbDate1.Name = "cmbDate1";
            this.cmbDate1.Size = new System.Drawing.Size(281, 38);
            this.cmbDate1.TabIndex = 10;
            // 
            // cmbDate2
            // 
            this.cmbDate2.Location = new System.Drawing.Point(95, 111);
            this.cmbDate2.Name = "cmbDate2";
            this.cmbDate2.Size = new System.Drawing.Size(281, 38);
            this.cmbDate2.TabIndex = 11;
            // 
            // ForOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 255);
            this.Controls.Add(this.cmbDate2);
            this.Controls.Add(this.cmbDate1);
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
        private CmbDate cmbDate1;
        private CmbDate cmbDate2;
    }
}