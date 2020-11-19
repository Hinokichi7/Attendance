using Attendance_APP.Dao;
using Attendance_APP.Dto;
using Attendance_APP.Util;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Attendance_APP
{
    public partial class Stamping : Form
    {
        //ComboBoxにて表示・選択
        //private List<EmployeeDto> EmployeeList { get; set; }
        private List<StampingTypeDto> StampingTypeList { get; set; }
        // 社員①の最新の打刻データ
        private StampingDto LatestStamping { get; set; }

        public Stamping()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            //cmbにて表示・選択
            //this.EmployeeList = new EmployeeDao().GetAllEmployee();
            this.StampingTypeList = new StampingTypeDao().GetAllStampingType();
            //this.SetCmbEmployee();
            //this.SetCmbStampingType();

            // タイマー設定
            timer1.Interval = 1000;
            timer1.Enabled = true;
            // ラベル設定  
            //departmentName.Text = this.GetSelectedEmployeeDepartment().Name;
            currentTime.Text = this.GetCurrentTime();
            this.cmbEmployee1.StatusUpdated += new EventHandler(MyEventHandlerFunction_StatusUpdated);
        }

        public void MyEventHandlerFunction_StatusUpdated(object sender, EventArgs e)
        {
            this.GetAttendanceOrLeaving();
        }


        private void GetAttendanceOrLeaving()
        {
            // DBより最新のデータ読み込み
            this.LatestStamping = new StampingDao().GetLatestStamping(cmbEmployee1.GetSelectedEmployee().Code);
            // 新規(最新データがnull)であれば出勤画面
            // 既存で退勤時間が押されてあったら(退勤打刻が初期値でない)出勤画面
            if (this.LatestStamping == null || LatestStamping.LeavingWork.CompareTo(new DateTime()) != 0)
            {
                StampingAttendance();
            }
            else
            {
                StampingLeaving();
            }
        }

        // 出勤打刻画面
        private void StampingAttendance()
        {
            // 退勤ボタン不可
            StampBtn2.Enabled = false;
        }

        // 退勤打刻画面
        private void StampingLeaving()
        {
            // cmb_stampingTypeに設定・表示
            cmbStampingType1.SetLatestStampingType(this.LatestStamping);
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
            dto.EmployeeCode = cmbEmployee1.GetSelectedEmployee().Code;
            dto.CreateTime = DateTime.Now;
            dto.Year = DateTime.Now.Year;
            dto.Month = DateTime.Now.Month;
            dto.Day = DateTime.Now.Day;
            dto.Attendance = DateTime.Now;
            dto.StampingCode = cmbStampingType1.GetSelectedStampingType().StampingCode;
            new StampingDao().AddStamping(dto);
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
            dto.UpdateTime = DateTime.Now;
            dto.LeavingWork = DateTime.Now;
            // 出勤時間、退勤時間を取得(丸め無し)
            var startTime = new WorkingHours().GetStartTime(this.LatestStamping.Attendance);
            var endTime = new WorkingHours().GetEndTime(dto.LeavingWork);
            // 労働時間
            dto.WorkingHours = new WorkingHours().GetWorkingHours(startTime, endTime);

            // 出勤打刻データに対して退勤打刻、労働時間をStampingDaoへ
            dto.Id = this.LatestStamping.Id;
            new StampingDao().UpdateStamping(dto);
        }
    }
}
