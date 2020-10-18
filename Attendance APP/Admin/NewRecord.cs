using Attendance_APP.Dao;
using Attendance_APP.Dto;
using Attendance_APP.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_APP
{
    public partial class NewRecord : Form
    {
        private List<EmployeeDto> EmployeeList { get; set; }
        private List<StampingTypeDto> StampingTypeList { get; set; }

        public NewRecord()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.EmployeeList = new EmployeeDao().GetAllEmployee();
            this.StampingTypeList = new StampingTypeDao().GetAllStampingType();
            this.SetCmbEmployee();
            this.SetCmbStampingType();
            this.InitializeCmbBox();
        }

        // 社員選択
        public void SetCmbEmployee()
        {
            cmb_employee.DataSource = this.EmployeeList;
            cmb_employee.ValueMember = "Code";
            cmb_employee.DisplayMember = "Name";
            cmb_employee.SelectedIndex = -1;
        }

        private EmployeeDto GetSelectedEmployee()
        {
            if (cmb_employee.SelectedIndex == -1)
            {
                return null;
            }
            return this.EmployeeList.Find(employee => employee.Code == int.Parse(cmb_employee.SelectedValue.ToString()));
        }

        private void cmb_employee_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            var employee = this.GetSelectedEmployee();
            if (employee != null)
            {
                departmentName.Text = new DepartmentDao().GetAllDepartment().Find(department => department.Code == employee.DepartmentCode).Name;
            }
        }

        // 打刻種類選択
        private void SetCmbStampingType()
        {
            cmb_stampingType.DataSource = new StampingTypeDao().GetAllStampingType();
            cmb_stampingType.ValueMember = "StampingCode";
            cmb_stampingType.DisplayMember = "StampingName";
            cmb_stampingType.SelectedIndex = -1;
        }

        private void InitializeCmbBox()
        {
            // cmbに設定・表示
            this.SetCmbYear(cmb_year);
            this.SetCmbBox(cmb_month, 12);

            this.SetCmbBoxTime(cmb_startHour, 1, 24, 8);
            this.SetCmbBoxTime(cmb_startMinut, 0, 59, 0);
            this.SetCmbBoxTime(cmb_endHour, 1, 24, 17);
            this.SetCmbBoxTime(cmb_endMinut, 0, 59, 0);
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

        // 年、月が選択される度に日付候補取得
        private void cmb_year_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.SetCmbBoxDay(cmb_year, cmb_month, cmb_day);
        }

        private void cmb_month_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.SetCmbBoxDay(cmb_year, cmb_month, cmb_day);
        }

        private DateTime GetStampingTime(ComboBox cmbHour, ComboBox cmbmMinut)
        {
            return DateTime.Parse(string.Format($"{cmb_year.SelectedValue:d4}/{cmb_month.SelectedItem:d2}/{cmb_day.SelectedItem:d2} {cmbHour.SelectedItem:d2}:{cmbmMinut.SelectedItem:d2}:00"));
        }


        private void SetCmbBoxTime(ComboBox cmb, int n, int max, int ix)
        {
            for (var i = n; i <= max; i++)
            {
                cmb.Items.Add(i);
            }
            cmb.SelectedIndex = ix;
            cmb.FormatString = "00";
        }

        private StampingTypeDto GetSelectedStampingType()
        {
            if (cmb_stampingType.SelectedIndex == -1)
            {
                return null;
            }
            return this.StampingTypeList.Find(stampingType => stampingType.StampingCode == int.Parse(cmb_stampingType.SelectedValue.ToString()));
        }


        private void AddNewRecord_Click_1(object sender, EventArgs e)
        {
            var dto = new StampingDto();
            dto.EmployeeCode = this.GetSelectedEmployee().Code;
            dto.CreateTime = DateTime.Now;
            dto.Year = (int)cmb_year.SelectedValue;
            dto.Month = (int)cmb_month.SelectedItem;
            dto.Day = (int)cmb_day.SelectedItem;
            dto.Attendance = this.GetStampingTime(cmb_startHour, cmb_startMinut);
            dto.LeavingWork = this.GetStampingTime(cmb_endHour, cmb_endMinut);
            dto.StampingCode = this.GetSelectedStampingType().StampingCode;
            // 出勤時間、退勤時間を取得(丸め無し)
            var startTime = new WorkingHours().GetStartTime(this.GetStampingTime(cmb_startHour, cmb_startMinut));
            var endTime = new WorkingHours().GetEndTime(this.GetStampingTime(cmb_endHour, cmb_endMinut));
            // 労働時間
            dto.WorkingHours = new WorkingHours().GetWorkingHours(startTime, endTime);
            dto.Remark = remark.Text;
            new StampingDao().AddNewRecord(dto);
            this.Close();
        }
    }
}
