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
        private List<EmployeeDto> Tbl_employee { get; set; }

        public NewRecord()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            this.SetEmployList(cmb_employee);
            this.InitializeCmbBox();
        }

        private void SetEmployList(ComboBox cmb)
        {
            // 社員を取得
            this.Tbl_employee = new EmployeeDao().GetAllEmployee();
            // cmbに設定・表示
            cmb.DataSource = this.Tbl_employee;
            cmb.ValueMember = "Code";
            cmb.DisplayMember = "Name";
        }

        private EmployeeDto GetSelectedEmployee()
        {
            return this.Tbl_employee.Find(employee => employee.Code == int.Parse(cmb_employee.SelectedValue.ToString()));
        }
        private void cmb_employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            departmentName.Text = new DepartmentDao().GetAllDepartment().Find(department => department.Code == this.GetSelectedEmployee().DepartmentCode).Name;
        }


        private void InitializeCmbBox()
        {
            // cmbに設定・表示
            // StampingDaoより年取得
            new SetCmbDate().SetCmbBox(cmb_year, new StampingDao().GetStampingYears(), "Year", "Year");
            new SetCmbDate().SetCmbBox(cmb_month, 12);
            this.SetCmbBoxDay(cmb_year, cmb_month, cmb_day);

            this.SetCmbBoxTime(cmb_startHour, 1, 24, 8);
            this.SetCmbBoxTime(cmb_startMinut, 0, 59, 0);
            this.SetCmbBoxTime(cmb_endHour, 1, 24, 17);
            this.SetCmbBoxTime(cmb_endMinut, 0, 59, 0);

            // cmb_stampingTypeに設定・表示
            new CmbStampingType().SetComBox(cmb_stampingType);
        }


        // 日付候補を取得
        private void SetCmbBoxDay(ComboBox cmb_year, ComboBox cmb_month, ComboBox cmb_day)
        {
            if (cmb_year.SelectedValue != null && cmb_month.SelectedItem != null)
            {
                cmb_day.Items.Clear();
                var maxDay = DateTime.DaysInMonth((int)cmb_year.SelectedValue, (int)cmb_month.SelectedItem);

                new SetCmbDate().SetCmbBox(cmb_day, maxDay);
            }
        }

        // 年、月が選択される度に日付候補取得
        private void cmb_startYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCmbBoxDay(cmb_year, cmb_month, cmb_day);
        }

        private void cmb_startMonth_SelectedIndexChanged(object sender, EventArgs e)
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



        private void AddNewRecord_Click(object sender, EventArgs e)
        {
            var dto = new StampingDto();
            dto.EmployeeCode = this.GetSelectedEmployee().Code;
            dto.CreateTime = DateTime.Now;
            dto.Year = (int)cmb_year.SelectedValue;
            dto.Month = (int)cmb_month.SelectedItem;
            dto.Day = (int)cmb_day.SelectedItem;
            dto.Attendance = this.GetStampingTime(cmb_startHour, cmb_startMinut);
            dto.LeavingWork = this.GetStampingTime(cmb_endHour, cmb_endMinut);
            dto.StampingCode = new CmbStampingType().GetSelectedStampingType(cmb_stampingType).StampingCode;
            // 出勤時間、退勤時間を取得(丸め無し)
            var startTime = new WorkingHours().GetStartTime(this.GetStampingTime(cmb_startHour, cmb_startMinut));
            var endTime = new WorkingHours().GetEndTime(this.GetStampingTime(cmb_endHour, cmb_endMinut));
            // 労働時間
            dto.WorkingHours = new WorkingHours().GetWorkingHours(startTime, endTime);
            dto.Remark = textBox1.Text;
            new AdminMenu().ShowDialog(this);
            new StampingDao().AddNewRecord(dto);
            this.Close();
        }
    }
}
