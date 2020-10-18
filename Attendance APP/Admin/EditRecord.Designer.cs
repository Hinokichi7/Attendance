namespace Attendance_APP
{
    partial class EditRecord
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
            this.class11 = new Attendance_APP.CmbEmployee();
            this.SuspendLayout();
            // 
            // class11
            // 
            this.class11.FormattingEnabled = true;
            this.class11.Location = new System.Drawing.Point(267, 151);
            this.class11.Name = "class11";
            this.class11.Size = new System.Drawing.Size(121, 20);
            this.class11.TabIndex = 0;
            // 
            // EditRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.class11);
            this.Name = "EditRecord";
            this.Text = "編集";
            this.ResumeLayout(false);

        }

        #endregion

        private CmbEmployee class11;
    }
}