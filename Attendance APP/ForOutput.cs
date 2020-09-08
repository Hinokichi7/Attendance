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
            this.initializeCmbBox();
        }

        private void initializeCmbBox() 
        {
            this.SetCmbBoxItem(cmb_startYear, new StampingDao().GetStampingYears(), "Year", "Year");
            this.SetCmbBoxItem(cmb_startMonth, 12);
            //this.setCmbBoxItem(cmb_startMonth, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            cmb_startYear.SelectedIndex  = 0;
            cmb_startMonth.SelectedIndex  = 0;

            this.SetCmbBoxItem(cmb_endYear, new StampingDao().GetStampingYears(), "Year", "Year");
            this.SetCmbBoxItem(cmb_endMonth, 12);
            //this.setCmbBoxItem(cmb_endMonth, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
        }

        private void SetCmbBoxItem(ComboBox cmb, List<StampingDto> item, String DisplayMember, String ValueMember) 
        {
            cmb.DataSource = item;
            cmb.ValueMember = ValueMember;
            cmb.DisplayMember = DisplayMember;
            cmb.SelectedIndex = 0;
        }

        private void SetCmbBoxItem(ComboBox cmb, int max)
        {
            for (var i = 1; i <= max; i++)
            {
                cmb.Items.Add(i);
            }
            cmb.SelectedIndex = 0;
        }
        //private void setCmbBoxItem(ComboBox cmb, int[] items)
        //{
        //    foreach (var item in items)
        //    {
        //        cmb.Items.Add(item);
        //    }
        //}

        private void SetCmbBoxItem(ComboBox cmb_year, ComboBox cmb_month, ComboBox cmb_day)
        {
            if (cmb_year.SelectedValue != null && cmb_month.SelectedItem != null)
            {
                cmb_day.Items.Clear();
                var maxDay = DateTime.DaysInMonth((int)cmb_year.SelectedValue, (int)cmb_month.SelectedItem);
                //for (var i = 1; i <= maxDay; i++)
                //{
                //    cmb_Day.Items.Add(i);
                //}
                SetCmbBoxItem(cmb_day, maxDay);
            }
        }

        private void xxxxx()
        {
            // 年度と月が選択されている事を確認する
            // 年度と月の両方が選択されている場合、その年月の最大の日（月の終わりの日）を取得する
            // 最大の日分の日付をcmbに追加する
        }

        private void cmb_startYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxItem(cmb_startYear, cmb_startMonth, cmb_startDay);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxItem(cmb_startYear, cmb_startMonth, cmb_startDay);
        }

        private void cmb_endYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxItem(cmb_endYear, cmb_endMonth, cmb_endDay);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxItem(cmb_endYear, cmb_endMonth, cmb_endDay);
        }

        private void outputCsv_Click(object sender, EventArgs e)
        {
            var date1 = DateTime.Parse(string.Format($"{cmb_startYear.SelectedValue:d4}/{cmb_startMonth.SelectedItem:d2}/{cmb_startDay.SelectedItem:d2} 00:00:00"));
            var date2 = DateTime.Parse(string.Format($"{cmb_endYear.SelectedValue:d4}/{cmb_endMonth.SelectedItem:d2}/{cmb_endDay.SelectedItem:d2} 00:00:00"));
            // 期間開始と終了が正しく選択できていれば保存
            // (引数が数が多く長いのでまとめられないか)
            if (date1 < date2)
            {
                new OutputFile().SaveFileDialog((int)cmb_startYear.SelectedValue, (int)cmb_startMonth.SelectedItem, (int)cmb_startDay.SelectedItem, (int)cmb_endYear.SelectedValue, (int)cmb_endMonth.SelectedItem, (int)cmb_endDay.SelectedItem);
            }
            else
            {
                MessageBox.Show("正しい期間を選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
