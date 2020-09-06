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
            this.setCmbBoxItem(cmb_startYear, new StampingDao().GetStampingYears(), "Year", "Year");
            this.setCmbBoxItem(cmb_startMonth, 12);
            //this.setCmbBoxItem(cmb_startMonth, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            cmb_startYear.SelectedIndex  = 0;
            cmb_startMonth.SelectedIndex  = 0;

            this.setCmbBoxItem(cmb_endYear, new StampingDao().GetStampingYears(), "Year", "Year");
            this.setCmbBoxItem(cmb_endMonth, 12);
            //this.setCmbBoxItem(cmb_endMonth, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            cmb_endYear.SelectedIndex = 0;
            cmb_endMonth.SelectedIndex = 0;
        }

        private void setCmbBoxItem(ComboBox cmb, List<StampingDto> item, String DisplayMember, String ValueMember) 
        {
            cmb.DataSource = item;
            cmb.ValueMember = ValueMember;
            cmb.DisplayMember = DisplayMember;
            Console.WriteLine(item.Count);  
        }

        private void setCmbBoxItem(ComboBox cmb, int max)
        {
            for (var i = 1; i <= max; i++)
            {
                cmb.Items.Add(i);
            }
        }
        //private void setCmbBoxItem(ComboBox cmb, int[] items)
        //{
        //    foreach (var item in items)
        //    {
        //        cmb.Items.Add(item);
        //    }
        //}


        private void setCmbBoxItem(ComboBox cmb_Year, ComboBox cmb_Month, ComboBox cmb_Day)
        {
            if (cmb_Year.SelectedValue != null && cmb_Month.SelectedItem != null)
            {
                Console.WriteLine("notYearNullAndNotMonthNull");
                cmb_Day.Items.Clear();
                int selectedYear = (int)cmb_Year.SelectedValue;
                int selectedMonth = (int)cmb_Month.SelectedItem;
                var maxDay = DateTime.DaysInMonth(selectedYear, selectedMonth);
                //for (var i = 1; i <= maxDay; i++)
                //{
                //    cmb_Day.Items.Add(i);
                //}
                setCmbBoxItem(cmb_Day, maxDay);
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
            this.setCmbBoxItem(cmb_startYear, cmb_startMonth, cmb_startDay);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setCmbBoxItem(cmb_startYear, cmb_startMonth, cmb_startDay);
        }

        private void cmb_endYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setCmbBoxItem(cmb_endYear, cmb_endMonth, cmb_endDay);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setCmbBoxItem(cmb_endYear, cmb_endMonth, cmb_endDay);
        }

        private void outputCsv_Click(object sender, EventArgs e)
        {
            if (cmb_startDay.SelectedItem != null && cmb_endDay.SelectedItem!= null)
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
