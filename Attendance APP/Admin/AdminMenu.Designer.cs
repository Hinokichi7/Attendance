namespace Attendance_APP
{
    partial class AdminMenu
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
            this.NewRecord = new System.Windows.Forms.Button();
            this.EditRecord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewRecord
            // 
            this.NewRecord.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NewRecord.Location = new System.Drawing.Point(162, 95);
            this.NewRecord.Name = "NewRecord";
            this.NewRecord.Size = new System.Drawing.Size(123, 58);
            this.NewRecord.TabIndex = 0;
            this.NewRecord.Text = "新規";
            this.NewRecord.UseVisualStyleBackColor = true;
            this.NewRecord.Click += new System.EventHandler(this.NewRecord_Click);
            // 
            // EditRecord
            // 
            this.EditRecord.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EditRecord.Location = new System.Drawing.Point(159, 205);
            this.EditRecord.Name = "EditRecord";
            this.EditRecord.Size = new System.Drawing.Size(123, 58);
            this.EditRecord.TabIndex = 1;
            this.EditRecord.Text = "編集";
            this.EditRecord.UseVisualStyleBackColor = true;
            this.EditRecord.Click += new System.EventHandler(this.EditRecord_Click);
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 345);
            this.Controls.Add(this.EditRecord);
            this.Controls.Add(this.NewRecord);
            this.Name = "AdminMenu";
            this.Text = "AnminMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewRecord;
        private System.Windows.Forms.Button EditRecord;
    }
}