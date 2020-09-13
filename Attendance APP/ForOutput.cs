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
            
            this.InitializeCmbBox();
        }

        private void InitializeCmbBox() 
        {
            // cmbに設定・表示
            // StampingDaoより年取得
            this.SetCmbBox(cmb_startYear, new StampingDao().GetStampingYears(), "Year", "Year");
            this.SetCmbBox(cmb_endYear, new StampingDao().GetStampingYears(), "Year", "Year");

            this.SetCmbBox(cmb_startMonth, 12);
            this.SetCmbBox(cmb_endMonth, 12);
        }

        private void SetCmbBox(ComboBox cmb, List<StampingDto> list, String DisplayMember, String ValueMember) 
        {
            cmb.DataSource = list;
            cmb.ValueMember = ValueMember;
            cmb.DisplayMember = DisplayMember;
            cmb.SelectedIndex = 0;
        }

        // 1からmaxまでの数値をcmb.Itemに追加
        private void SetCmbBox(ComboBox cmb, int max)
        {
            for (var i = 1; i <= max; i++)
            {
                cmb.Items.Add(i);
            }
            cmb.SelectedIndex = 0;
        }

        // 日付候補を取得
        private void SetCmbBoxDay(ComboBox cmb_year, ComboBox cmb_month, ComboBox cmb_day)
        {
            if (cmb_year.SelectedValue != null && cmb_month.SelectedItem != null)
            {
                cmb_day.Items.Clear();
                var maxDay = DateTime.DaysInMonth((int)cmb_year.SelectedValue, (int)cmb_month.SelectedItem);

                SetCmbBox(cmb_day, maxDay);
            }
        }

        // 年、月が選択される度に日付候補取得
        private void cmb_startYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxDay(cmb_startYear, cmb_startMonth, cmb_startDay);
        }

        private void cmb_startMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxDay(cmb_startYear, cmb_startMonth, cmb_startDay);
        }

        private void cmb_endYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxDay(cmb_endYear, cmb_endMonth, cmb_endDay);
        }

        private void cmb_emdMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxDay(cmb_endYear, cmb_endMonth, cmb_endDay);
        }

        private void outputCsv_Click(object sender, EventArgs e)
        {
            // 選択された年月日の数値を日付に変換
            var date1 = DateTime.Parse(string.Format($"{cmb_startYear.SelectedValue:d4}/{cmb_startMonth.SelectedItem:d2}/{cmb_startDay.SelectedItem:d2} 00:00:00"));
            var date2 = DateTime.Parse(string.Format($"{cmb_endYear.SelectedValue:d4}/{cmb_endMonth.SelectedItem:d2}/{cmb_endDay.SelectedItem:d2} 00:00:00"));
            // 期間開始と終了が正しく選択できていれば保存
            if (date1 < date2)
            {
                // 年月日の数字をSQL期間指定用文字列へ
                var starPoint = $"{(int)cmb_startYear.SelectedValue}-{(int)cmb_startMonth.SelectedItem:d2}-{(int)cmb_startDay.SelectedItem:d2}";
                var endPoint = $"{(int)cmb_endYear.SelectedValue}-{(int)cmb_endMonth.SelectedItem:d2}-{(int)cmb_endDay.SelectedItem:d2}";
                new OutputFile().SaveFileDialog(starPoint, endPoint);
            }
            else
            {
                MessageBox.Show("正しい期間を選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
