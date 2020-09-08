using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Attendance_APP
{
    public partial class Stamping : Form
    {
        // Menuにて選択した社員①
        private readonly EmployeeDto employee;
        // 打刻時間丸め設定
        private TimeSpan interval = TimeSpan.FromMinutes(30);
        // 勤務種別
        private List<StampingTypeDto> list;

        public Stamping(EmployeeDto employee)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.employee = employee;
            // タイマー設定
            timer1.Interval = 1000;
            timer1.Enabled = true;
            // ラベル設定
            currentTime.Text = this.GetCurrentTime();
            employeeName.Text = this.employee.Name;
            // cmbに設定(勤務種別)
            this.SetCmb_StampingType(cmb_stampingType);
        }

        private void SetCmb_StampingType(ComboBox cmb)
        {
            // 勤務種別を取得
            this.list = new StampingTypeDao().GetAllStampingType();
            // cmbに設定・表示
            cmb.DataSource = this.list;
            cmb.ValueMember = "StampingCode";
            cmb.DisplayMember = "StampingName";
        }

        private StampingTypeDto GetSelectedStampingType()
        {
            return this.list.Find(stampingType => stampingType.StampingCode == int.Parse(cmb_stampingType.SelectedValue.ToString()));
        }

        // 現在時刻表示
        private string GetCurrentTime() 
        {
            return $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
        }
        // タイマー表示
        private void timer1_Tick(object sender, EventArgs e)
        {
            currentTime.Text = this.GetCurrentTime();
        }

  
        private void stampBtn_Click(object sender, EventArgs e)
        {
            // 出勤時間の表示
            TimeStamp.Text = GetCurrentTime();
            // 出勤打刻データをStamping.Daoへ
            var dto = new StampingDto();
            dto.EmployeeCode = this.employee.Code;
            dto.Year = DateTime.Now.Year;
            dto.Month = DateTime.Now.Month;
            dto.Day = DateTime.Now.Day;
            dto.Attendance = DateTime.Now;
            dto.StampingCode = GetSelectedStampingType().StampingCode;
            new StampingDao().AttendanceStamping(dto);
        }

        private void StampBtn2_Click(object sender, EventArgs e)
        {
            // 退勤時間を表示
            TimeStamp.Text = GetCurrentTime();
            // 退勤打刻データをStampingDaoへ(①社員、現在日付指定)
            var dto = new StampingDto();
            dto.LeavingWork = DateTime.Now;
            dto.EmployeeCode = this.employee.Code;
            dto.Year = DateTime.Now.Year;
            dto.Month = DateTime.Now.Month;
            dto.Day = DateTime.Now.Day;
            // 出勤打刻データを取得(①社員、現在日付指定)
            var startDto = new StampingDao().GetAttendance(this.employee.Code, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var startTime = GetStartTime(startDto.Attendance);
            var endTime = GetEndTime(dto.LeavingWork);
            dto.WorkingHours = HourDifference(startTime, endTime);
            new StampingDao().LeavingWorkStamping(dto);
        }

        // 労働時間計算　退勤時間(丸め) - 出勤時間(丸め)
        private double HourDifference(DateTime startTime, DateTime endTime)
        {
            Console.WriteLine(startTime.ToString());
            Console.WriteLine(endTime.ToString());
            var hourDeffrence = endTime - startTime;
            if (hourDeffrence.TotalHours < 0.5)
            {
                return 0;
            }
            return hourDeffrence.TotalHours;
        }

        private DateTime GetStartTime(DateTime startTime)
        {
            // 出勤時間(丸め)：定時以前なら定時、定時以降なら切り上げ
            var baseTime = DateTime.Parse($"{startTime.Year}/{startTime.Month}/{startTime.Day} 09:00:00");
            if (startTime > baseTime)
            {
                return RoundUp(startTime, interval);
            }
            return baseTime;
        }

        private DateTime GetEndTime(DateTime endTime)
        {
            // 退勤時間(丸め)：切り下げ
            return RoundDown(endTime, this.interval);
        }

        private DateTime RoundUp(DateTime input, TimeSpan interval)
        {
            return new DateTime(((input.Ticks + interval.Ticks - 1) / interval.Ticks) * interval.Ticks, input.Kind);
        }

        private DateTime RoundDown(DateTime input, TimeSpan interval)
        {
            return new DateTime((((input.Ticks + interval.Ticks) / interval.Ticks) - 1) * interval.Ticks, input.Kind);
        }

    }
}
