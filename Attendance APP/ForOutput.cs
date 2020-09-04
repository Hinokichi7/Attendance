using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Attendance_APP.Util;
using System.Globalization;

namespace Attendance_APP
{
    public partial class ForOutput : Form
    {
        private List<StampingDto> yearsList1;
        private List<StampingDto> monthList1;
        private List<StampingDto> yearsList2;
        private List<StampingDto> monthList2;

        private List<StampingDto> resultSetYears;
        private List<StampingDto> resultSetMonths;
        private int maxDay;

        public int? year1;
        public int? month1;
        public int? day1;
        public int? year2;
        public int? month2;
        public int? day2;

        public ForOutput()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            comboBox1.Text = "年";
            comboBox2.Text = "月";
            comboBox3.Text = "日";
            comboBox4.Text ="年";
            comboBox5.Text = "月";
            comboBox6.Text = "日";
        }


        private void SetStampingYearList()
        {
            this.resultSetYears = new StampingDao().GetStampingYears();
        }

        private void SetStampingMonthList(int? selectedYear)
        {
            if (selectedYear != null)
            {
                this.resultSetMonths = new StampingDao().GetStampingMonths(selectedYear);
            }
        }

        private void SetStampingDaysList(int? selectedYear, int? selectedMonth)
        {
            if (selectedMonth != null)
            {
                var sy = (int)selectedYear;
                var sm = (int)selectedMonth;
                this.maxDay = DateTime.DaysInMonth(sy, sm);
            }
        }

        public void AddYearsListItem()
        {
            comboBox1.DataSource = yearsList1;
            comboBox1.ValueMember = "Year";
            comboBox1.DisplayMember = "Year";
        }

        public void AddYearsListItem2()
        {
            comboBox4.DataSource = yearsList2;
            comboBox4.ValueMember = "Year";
            comboBox4.DisplayMember = "Year";
        }

        public void AddMonthListItem()
        {
            comboBox2.DataSource = monthList1;
            comboBox2.ValueMember = "Month";
            comboBox2.DisplayMember = "Month";

        }

        public void AddMonthListItem2()
        {
            comboBox5.DataSource = monthList2;
            comboBox5.ValueMember = "Month";
            comboBox5.DisplayMember = "Month";
        }

        private void comboBox1_DropDownOpend(object sender, EventArgs e)
        {
            this.SetStampingYearList();
            this.yearsList1 = this.resultSetYears;
            this.AddYearsListItem();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.year1 = comboBox1.SelectedValue as int?;
            this.SetStampingMonthList(year1);
            this.monthList1 = this.resultSetMonths;
            this.AddMonthListItem();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            this.month1 = comboBox2.SelectedValue as int?;
            this.SetStampingDaysList(year1, month1);
            for (var i = 1; i <= this.maxDay; i++)
            {
                comboBox3.Items.Add(i);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.day1 = comboBox3.SelectedItem as int?;
        }

        private void comboBox4_DropDownOpend(object sender, EventArgs e)
        {
            this.SetStampingYearList();
            this.yearsList2 = this.resultSetYears;
            this.AddYearsListItem2();
        }
        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.year2 = comboBox4.SelectedValue as int?;
            this.SetStampingMonthList(year2);
            this.monthList2 = this.resultSetMonths;
            this.AddMonthListItem2();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            this.month2 = comboBox5.SelectedValue as int?;
            this.SetStampingDaysList(year2, month2);
            for (var i = 1; i <= this.maxDay; i++)
            {
                comboBox6.Items.Add(i);
            }
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.day2 = comboBox6.SelectedItem as int?;
        }


        private void outputCsv_Click(object sender, EventArgs e)
        {
            if (year1 != null && month1 != null && day1 != null && year2 != null && month2 != null && day2 != null)
            {
            new OutputFile().SaveFileDialog(year1, month1, day1, year2, month2, day2);
            }
            else
            {
                MessageBox.Show("正しい期間を選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
