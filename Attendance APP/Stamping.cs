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
        private EmployeeDto Employee { get; set; }
        // 社員①の最新の打刻データ
        private StampingDto LatestStamping { get; set; }
        // 打刻時間丸め設定
        private TimeSpan interval = TimeSpan.FromMinutes(30);
        // 勤務種別
        private List<StampingTypeDto> Tbl_stampimgType { get; set; }

        public Stamping(EmployeeDto employee)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Employee = employee;
            // タイマー設定
            timer1.Interval = 1000;
            timer1.Enabled = true;
            // ラベル設定
            currentTime.Text = this.GetCurrentTime();
            employeeName.Text = this.Employee.Name;

            // 打刻画面表示選択
            this.GetAttendanceOrLeaving();
            
        }

        private void GetAttendanceOrLeaving()
        {
            // 社員①の打刻データが既存か新規か
            //var exitsEmployee = new StampingDao().GetAllStamping().Find(employee => employee.EmployeeCode == this.Employee.Code);
            //if (exitsEmployee != null)
            //{
                // 既存の場合→最新のデータ読み込み
                this.LatestStamping = new StampingDao().GetLatestStamping(this.Employee.Code);
                // 退勤時間が押されているかどうか(初期値の場合は押されていない)
                if (this.LatestStamping == null || LatestStamping.LeavingWork.CompareTo(new DateTime()) != 0)
                {
                    StampingAttendance();
                }
                else
                {
                    StampingLeaving();
                }
            //}
            //else
            //{
            //    // 新規の場合→出勤打刻画面
            //    StampingAttendance();
            //}
        }

        // 出勤打刻画面
        private void StampingAttendance()
        {
            // 全勤務種別をStampingDaoより取得
            this.Tbl_stampimgType = new StampingTypeDao().GetAllStampingType();
            // cmb_stampingTypeに設定・表示
            cmb_stampingType.DataSource = this.Tbl_stampimgType;
            cmb_stampingType.ValueMember = "StampingCode";
            cmb_stampingType.DisplayMember = "StampingName";
            // 退勤ボタン不可
            StampBtn2.Enabled = false;
        }

        // 退勤打刻画面
        private void StampingLeaving()
        {
            // cmb_stampingTypeに設定・表示
            var list = new StampingTypeDao().GetAllStampingType();
            cmb_stampingType.Text = list.Find(stampingType => stampingType.StampingCode == this.LatestStamping.StampingCode).StampingName;
            // 出勤ボタン不可
            stampBtn.Enabled = false;
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

        // 出勤打刻ボタン
        private void stampBtn_Click(object sender, EventArgs e)
        {
            // 打刻ボタン2度押し不可
            stampBtn.Enabled = false;
            // 打刻時間の表示
            TimeStamp.Text = GetCurrentTime();
            // 打刻データをStamping.Daoへ(追加)
            var dto = new StampingDto();
            dto.EmployeeCode = this.Employee.Code;
            dto.Year = DateTime.Now.Year;
            dto.Month = DateTime.Now.Month;
            dto.Day = DateTime.Now.Day;
            dto.Attendance = DateTime.Now;
            dto.StampingCode = GetSelectedStampingType().StampingCode;
            new StampingDao().AddStamping(dto);
        }
        // 勤務種別選択
        private StampingTypeDto GetSelectedStampingType()
        {
            return this.Tbl_stampimgType.Find(stampingType => stampingType.StampingCode == int.Parse(cmb_stampingType.SelectedValue.ToString()));
        }

        // 退勤打刻ボタン
        private void StampBtn2_Click(object sender, EventArgs e)
        {
            // 打刻ボタン2度押し不可
            StampBtn2.Enabled = false;
            // 打刻時間を表示
            TimeStamp.Text = GetCurrentTime();
            // 退勤打刻データ→<StampingDto>
            var dto = new StampingDto();
            dto.EmployeeCode = this.Employee.Code;
            // 退勤時間
            dto.LeavingWork = DateTime.Now;

            // 出勤時間、退勤時間を取得(丸め無し)
            var startTime = GetStartTime(this.LatestStamping.Attendance);
            var endTime = GetEndTime(dto.LeavingWork);
            // ②より労働時間を取得
            dto.WorkingHours = HourDifference(startTime, endTime);

            // 退勤打刻データをStampingDaoへ
            var startDto = new StampingDao().GetLatestStamping(dto.EmployeeCode);
            dto.Id = startDto.Id;
            new StampingDao().UpdateStamping(dto);
        }

        //private void StampBtn2_Click(object sender, EventArgs e)
        //{
        //    // 退勤時間を表示
        //    TimeStamp.Text = GetCurrentTime();
        //    // 退勤打刻データ→<StampingDto>
        //    var dto = new StampingDto();
        //    // 退勤時間
        //    dto.LeavingWork = DateTime.Now;

        //    // 労働時間取得
        //    // 出勤打刻データ取得用
        //    dto.EmployeeCode = this.employee.Code;
        //    dto.Year = DateTime.Now.Year;
        //    dto.Month = DateTime.Now.Month;
        //    dto.Day = DateTime.Now.Day;
        //    // 出勤打刻データをStampingDaoより取得(社員①、現在日付指定)
        //    var startDto = new StampingDao().GetAttendance(this.employee.Code, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //    // 出勤時間、退勤時間を取得(丸め無し)
        //    var startTime = GetStartTime(startDto.Attendance);
        //    var endTime = GetEndTime(dto.LeavingWork);
        //    // ②より労働時間を取得
        //    dto.WorkingHours = HourDifference(startTime, endTime);

        //    // 退勤打刻データをStampingDaoへ
        //    new StampingDao().LeavingWorkStamping(dto);
        //}

        // 労働時間計算　退勤時間(丸め) - 出勤時間(丸め)②
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
