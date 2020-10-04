using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_APP.Util
{
    class WorkingHours
    {
        private TimeSpan interval = TimeSpan.FromMinutes(30);

        // 労働時間計算　退勤時間(丸め) - 出勤時間(丸め)
        public double GetWorkingHours(DateTime startTime, DateTime endTime)
        {
            var workingHour = endTime - startTime;
            if (workingHour.TotalHours < 0.5)
            {
                return 0;

            }
            return workingHour.TotalHours;
        }

        public DateTime GetStartTime(DateTime startTime)
        {
            // 出勤時間(丸め)：定時以前なら定時、定時以降なら切り上げ
            var baseTime = DateTime.Parse($"{startTime.Year}/{startTime.Month}/{startTime.Day} 09:00:00");
            if (startTime > baseTime)
            {
                return RoundUp(startTime, this.interval);
            }
            return baseTime;
        }

        public DateTime GetEndTime(DateTime endTime)
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
