namespace Attendance_APP
{
    partial class Stamping
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.currentTime = new System.Windows.Forms.Label();
            this.stampBtn = new System.Windows.Forms.Button();
            this.TimeStamp = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmb_stampingType = new System.Windows.Forms.ComboBox();
            this.employeeName = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.StampBtn2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // currentTime
            // 
            this.currentTime.AutoSize = true;
            this.currentTime.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.currentTime.Location = new System.Drawing.Point(27, 120);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(186, 41);
            this.currentTime.TabIndex = 0;
            this.currentTime.Text = "Current time";
            // 
            // stampBtn
            // 
            this.stampBtn.BackColor = System.Drawing.Color.YellowGreen;
            this.stampBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stampBtn.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stampBtn.Location = new System.Drawing.Point(0, 0);
            this.stampBtn.Name = "stampBtn";
            this.stampBtn.Size = new System.Drawing.Size(410, 214);
            this.stampBtn.TabIndex = 1;
            this.stampBtn.Text = "出社";
            this.stampBtn.UseVisualStyleBackColor = false;
            this.stampBtn.Click += new System.EventHandler(this.stampBtn_Click);
            // 
            // TimeStamp
            // 
            this.TimeStamp.AutoSize = true;
            this.TimeStamp.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TimeStamp.Location = new System.Drawing.Point(31, 184);
            this.TimeStamp.Name = "TimeStamp";
            this.TimeStamp.Size = new System.Drawing.Size(111, 36);
            this.TimeStamp.TabIndex = 3;
            this.TimeStamp.Text = "打刻時間";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmb_stampingType);
            this.splitContainer1.Panel1.Controls.Add(this.employeeName);
            this.splitContainer1.Panel1.Controls.Add(this.currentTime);
            this.splitContainer1.Panel1.Controls.Add(this.TimeStamp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 6;
            // 
            // cmb_stampingType
            // 
            this.cmb_stampingType.FormattingEnabled = true;
            this.cmb_stampingType.Location = new System.Drawing.Point(56, 251);
            this.cmb_stampingType.Name = "cmb_stampingType";
            this.cmb_stampingType.Size = new System.Drawing.Size(121, 20);
            this.cmb_stampingType.TabIndex = 5;
            // 
            // employeeName
            // 
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.employeeName.Location = new System.Drawing.Point(27, 58);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(146, 41);
            this.employeeName.TabIndex = 0;
            this.employeeName.Text = "employee";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.stampBtn);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.StampBtn2);
            this.splitContainer2.Size = new System.Drawing.Size(410, 450);
            this.splitContainer2.SplitterDistance = 214;
            this.splitContainer2.TabIndex = 0;
            // 
            // StampBtn2
            // 
            this.StampBtn2.BackColor = System.Drawing.Color.Tan;
            this.StampBtn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StampBtn2.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StampBtn2.Location = new System.Drawing.Point(0, 0);
            this.StampBtn2.Name = "StampBtn2";
            this.StampBtn2.Size = new System.Drawing.Size(410, 232);
            this.StampBtn2.TabIndex = 1;
            this.StampBtn2.Text = "退社";
            this.StampBtn2.UseVisualStyleBackColor = false;
            this.StampBtn2.Click += new System.EventHandler(this.StampBtn2_Click);
            // 
            // Stamping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Stamping";
            this.Text = "Stamping";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label currentTime;
        private System.Windows.Forms.Button stampBtn;
        private System.Windows.Forms.Label TimeStamp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button StampBtn2;
        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.ComboBox cmb_stampingType;
    }
}