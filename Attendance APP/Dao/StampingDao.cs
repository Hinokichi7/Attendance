using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Attendance_APP.Dao
{
    class StampingDao : Dao
    {
        private List<StampingDto> SetStampingDto(DataTable dt)
        {
            var list = new List<StampingDto>();
            foreach (DataRow dr in dt.Rows)
            {
                var dto = new StampingDto();

                if (dt.Columns.Contains("employeeCode"))
                {
                    dto.EmployeeCode = int.Parse(dr["employeeCode"].ToString());
                }
                if (dt.Columns.Contains("year"))
                {
                    dto.Year = int.Parse(dr["year"].ToString());
                }
                if (dt.Columns.Contains("month"))
                {
                    dto.Month = int.Parse(dr["month"].ToString());
                }
                if (dt.Columns.Contains("day"))
                {
                    dto.Day = int.Parse(dr["day"].ToString());
                }
                if (dt.Columns.Contains("attendance"))
                {
                    dto.Attendance = DateTime.Parse(dr["attendance"].ToString());
                }
                if (dt.Columns.Contains("stampingCode"))
                {
                    dto.StampingCode = int.Parse(dr["stampingcode"].ToString());
                }
                    if (dt.Columns.Contains("leavingWork") && !String.IsNullOrEmpty(dr["leavingWork"].ToString()))
                {
                    dto.LeavingWork = DateTime.Parse(dr["leavingWork"].ToString());
                }
                if (dt.Columns.Contains("workingHours") && !String.IsNullOrEmpty(dr["workingHours"].ToString()))
                {
                    dto.WorkingHours = double.Parse(dr["workingHours"].ToString());
                }
                list.Add(dto);
            }
            return list;
        }

        public StampingDto GetLatestStamping(int employeeCode)
        {
            // 社員を指定して最新の打刻データを読み込み
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("SELECT TOP 1 * FROM Attendance.dbo.Stamping WHERE employeeCode = @employeeCode ORDER BY id DESC", conn))
            {
                cmd.Parameters.AddWithValue("@employeeCode", employeeCode);

                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return this.SetStampingDto(dt)[0];
            }
        }

        public void AttendanceStamping(StampingDto dto)
        {
            // 社員コード、年月日、出勤時間、勤務種別を追加
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("INSERT INTO Attendance.dbo.Stamping(EmployeeCode, year, month, day, attendance, stampingCode) VALUES(@employeeCode,@year, @month, @day,@attendance,@stampingCode)", conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@employeeCode", dto.EmployeeCode);
                cmd.Parameters.AddWithValue("@year", dto.Year);
                cmd.Parameters.AddWithValue("@month", dto.Month);
                cmd.Parameters.AddWithValue("@day", dto.Day);
                cmd.Parameters.AddWithValue("@attendance", dto.Attendance);
                cmd.Parameters.AddWithValue("@stampingCode", dto.StampingCode);

                cmd.ExecuteNonQuery();

            }
        }

        public void LeavingWorkStamping(StampingDto dto)
        {
            // 社員を指定して退勤時刻、労働時間を更新
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("UPDATE Attendance.dbo.Stamping SET leavingWork = @leavingWork, workingHours = @workingHours WHERE employeeCode = @employeeCode AND workingHours IS NULL", conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@employeeCode", dto.EmployeeCode); ;
                cmd.Parameters.AddWithValue("@leavingWork", dto.LeavingWork);
                cmd.Parameters.AddWithValue("@workingHours", dto.WorkingHours);

                cmd.ExecuteNonQuery();

            }
        }
        //public void LeavingWorkStamping(StampingDto dto)
        //{
        //    // 社員、日付を指定して退勤時刻、労働時間を更新
        //    using (var conn = GetConnection())
        //    using (var cmd = new SqlCommand("UPDATE Attendance.dbo.Stamping SET leavingWork = @leavingWork, workingHours = @workingHours WHERE employeeCode = @employeeCode AND year = @year AND month = @month AND day= @day", conn))
        //    {
        //        conn.Open();

        //        cmd.Parameters.AddWithValue("@leavingWork", dto.LeavingWork);
        //        cmd.Parameters.AddWithValue("@employeeCode", dto.EmployeeCode);
        //        cmd.Parameters.AddWithValue("@year", dto.Year);
        //        cmd.Parameters.AddWithValue("@month", dto.Month);
        //        cmd.Parameters.AddWithValue("@day", dto.Day);
        //        cmd.Parameters.AddWithValue("@workingHours", dto.WorkingHours);

        //        cmd.ExecuteNonQuery();

        //    }
        //}

        public StampingDto GetAttendance(int employeeCode, int year, int month, int day)
        {
            //社員、年月日からStampingテーブルの行データを指定して読み込み
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping WHERE employeeCode = @employeeCode AND year = @year AND month = @month AND day= @day", conn))
            {

                cmd.Parameters.AddWithValue("@employeeCode", employeeCode);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@day", day);

                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return this.SetStampingDto(dt)[0];
            }
        }

 
        public List<StampingDto> GetAllStamping()
        {
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping", conn))
            {
                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return this.SetStampingDto(dt);
            }
        }

        public List<StampingDto> GetStampingYears()
        {
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("SELECT year FROM Attendance.dbo.Stamping GROUP BY year", conn))
            {
                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return this.SetStampingDto(dt);
            }
        }

        public List<StampingDto> GetTermStamping(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            //年月日１から年月日２の期間からStampingテーブルの行データを指定して読み込み
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping WHERE year BETWEEN @year1 AND @year2 AND month BETWEEN @month1 AND @month2 AND day BETWEEN @day1 AND @day2", conn))
            {
                cmd.Parameters.AddWithValue("@year1", year1);
                cmd.Parameters.AddWithValue("@month1", month1);
                cmd.Parameters.AddWithValue("@day1", day1);
                cmd.Parameters.AddWithValue("@year2", year2);
                cmd.Parameters.AddWithValue("@month2", month2);
                cmd.Parameters.AddWithValue("@day2", day2);
                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return this.SetStampingDto(dt);
            }
        }
    }
}
