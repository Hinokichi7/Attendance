using Attendance_APP.Dao;
using Attendance_APP.Dto;
using Attendance_APP.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Attendance_APP
{
    public partial class ForOutput : Form
    {
        public ForOutput()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

 

        private void outputCsv_Click(object sender, EventArgs e)
        {
            // 選択された年月日の数値を日付に変換
            var date1 = cmbDate1.GetSelectedDate();
            var date2 = cmbDate2.GetSelectedDate();
            // 期間開始と終了が正しく選択できていれば保存
            if (date1 < date2)
            {
                // 年月日の数字をSQL期間指定用文字列へ
                var starPoint = cmbDate1.GetSelectedPoint();
                var endPoint = cmbDate2.GetSelectedPoint();
                new OutputFile().SaveFileDialog(starPoint, endPoint);
            }
            else
            {
                MessageBox.Show("正しい期間を選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
