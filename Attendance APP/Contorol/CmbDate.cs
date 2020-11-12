using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Attendance_APP.Dao;
using Attendance_APP.Dto;

namespace Attendance_APP
{
    public partial class CmbDate : UserControl
    {
        public CmbDate()
        {
            InitializeComponent();
            this.InitializeCmbBox();
        }

        private void InitializeCmbBox()
        {
            // cmbに設定・表示
            this.SetCmbYear(cmb_year);
            this.SetCmbBox(cmb_month, 12);
        }

        public void SetCmbYear(ComboBox cmb)
        {
            cmb.DataSource = new StampingDao().GetStampingYears();
            cmb.ValueMember = "Year";
            cmb.DisplayMember = "Year";
            cmb.SelectedIndex = 0;
        }

        // 1からmaxまでの数値をcmb.Itemに追加
        public void SetCmbBox(ComboBox cmb, int max)
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

                this.SetCmbBox(cmb_day, maxDay);
            }
        }

        private void cmb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxDay(cmb_year, cmb_month, cmb_day);
        }

        private void cmb_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxDay(cmb_year, cmb_month, cmb_day);
        }

        public DateTime GetSelectedDate()
        {
            return DateTime.Parse(string.Format($"{cmb_year.SelectedValue:d4}/{cmb_month.SelectedItem:d2}/{cmb_day.SelectedItem:d2} 00:00:00"));
        }
        
        public string GetSelectedPoint()
        {
            return $"{(int)cmb_year.SelectedValue}-{(int)cmb_month.SelectedItem:d2}-{(int)cmb_day.SelectedItem:d2}";
        }

        public (int year, int month, int day) GetSelectedValue()
        {
            return ((int)cmb_year.SelectedValue, (int)cmb_month.SelectedItem, (int)cmb_day.SelectedItem);
        }

        public void GetSelectedValue2(StampingDto stamping)
        {
            cmb_year.Text = stamping.Year.ToString();
            cmb_month.Text = stamping.Month.ToString();
            cmb_day.Text = stamping.Day.ToString();
        }
    }
}
