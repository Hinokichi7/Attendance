using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Attendance_APP
{
    public partial class Stamping : Form
    {
        private EmployeeDto employee;
        private TimeSpan interval = TimeSpan.FromMinutes(30);
        private List<StampingTypeDto> list;
        public Stamping(EmployeeDto employee)
        {
            InitializeComponent();
            this.employee = employee;
            this.StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            label1.Text = this.GetCurrentTime();
            employeeName.Text = this.employee.Name;
            SetStampingTypeList();
            AddListItem();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = this.GetCurrentTime();
        }
        private string GetCurrentTime() {
            return DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        private void stampBtn_Click(object sender, EventArgs e)
        {
            TimeStamp.Text = GetCurrentTime();
            var dto = new StampingDto
            {
                EmployeeCode = employee.Code,
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                Day = DateTime.Now.Day,
                Attendance = DateTime.Now,
                StampingCode = GetSelectedStampingType().StampingCode,
            };
            new StampingDao().AttendanceStamping(dto);
        }

        private void StampBtn2_Click(object sender, EventArgs e)
        {
            TimeStamp.Text = GetCurrentTime();
            var startDto = new StampingDao().GetAttendance(employee.Code, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var dto = new StampingDto
            {
                LeavingWork = DateTime.Now,
                EmployeeCode = employee.Code,
                Year = DateTime.Now.Year,
                Month= DateTime.Now.Month,
                Day = DateTime.Now.Day,
            };
            var startTime = GetStartTime(startDto.Attendance);
            var endTime = RoundUp(dto.LeavingWork, this.interval);
            dto.WorkingHours = HourDifference(startTime, endTime);
            new StampingDao().LeavingWorkStamping(dto);
        }

        private double HourDifference(DateTime startTime, DateTime endTime)
        {
            Console.WriteLine(startTime.ToString());
            Console.WriteLine(endTime.ToString());
            var hourDeffrence = endTime - startTime;
            if(hourDeffrence.TotalHours < 0.5)
            {
                return 0;
            }
            return hourDeffrence.TotalHours;
        }

        private DateTime RoundUp(DateTime input, TimeSpan interval)
        {
            return new DateTime(((input.Ticks + interval.Ticks - 1) / interval.Ticks) * interval.Ticks, input.Kind);
        }

        private DateTime RoundDown(DateTime input, TimeSpan interval)
        {
            return new DateTime((((input.Ticks + interval.Ticks) / interval.Ticks) - 1) * interval.Ticks, input.Kind);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var start = DateTime.Parse("2020/01/01 09:00:01");
            var end = DateTime.Parse("2020/01/01 18:00:00");
            Console.WriteLine(this.HourDifference(this.GetStartTime(start), this.GetEndTime(end)));
        }
        
        private DateTime GetStartTime(DateTime startTime)
        {
            var baseTime  = DateTime.Parse($"{startTime.Year}/{startTime.Month}/{startTime.Day} 09:00:00");
            if (startTime > baseTime)
            {
                return RoundUp(startTime, interval);
            }
            return baseTime;
        }

        private DateTime GetEndTime(DateTime endTime)
        {
            return RoundDown(endTime, interval);
        }

        private void AddListItem()
        {
            comboBox2.DataSource = list;
            comboBox2.ValueMember = "StampingCode";
            comboBox2.DisplayMember = "StampingName";
        }
        private void SetStampingTypeList()
        {
            list = new StampingTypeDao().GetAllStampingType();
        }
        private StampingTypeDto GetSelectedStampingType()
        {
            return list.Find(stampingType => stampingType.StampingCode == int.Parse(comboBox2.SelectedValue.ToString()));
        }





        // private double calculateHours(DateTime start, DateTime end) {
        //     return 7.5;
        // }

        //private void AddListItem()
        //{
        //    var list = new EmployeeDao().GetAllEmployee();
        //    foreach (EmployeeDto item in list)
        //    {
        //        comboBox1.Items.Add(item.Name);
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var dao = new EmployeeDao();
        //    dao.GetAllEmployee();
        //}
    }
}
