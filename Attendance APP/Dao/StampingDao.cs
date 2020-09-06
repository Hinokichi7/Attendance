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

        public void AttendanceStamping(StampingDto dto)
        {
            using (var conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Attendance.dbo.Stamping(EmployeeCode, year, month, day, attendance, stampingCode) VALUES(@1,@2, @3, @4,@5,@7)", conn))
            {
                cmd.Parameters.AddWithValue("@1", dto.EmployeeCode);
                cmd.Parameters.AddWithValue("@2", dto.Year);
                cmd.Parameters.AddWithValue("@3", dto.Month);
                cmd.Parameters.AddWithValue("@4", dto.Day);
                cmd.Parameters.AddWithValue("@5", dto.Attendance);
                cmd.Parameters.AddWithValue("@7", dto.StampingCode);
                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void LeavingWorkStamping(StampingDto dto)
        {
            using (var conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("UPDATE Attendance.dbo.Stamping SET leavingWork = @leavingWork, workingHours = @workingHours WHERE employeeCode = @employeeCode AND year = @year AND month = @month AND day= @day", conn))
            {
                cmd.Parameters.AddWithValue("@leavingWork", dto.LeavingWork);
                cmd.Parameters.AddWithValue("@employeeCode", dto.EmployeeCode);
                cmd.Parameters.AddWithValue("@year", dto.Year);
                cmd.Parameters.AddWithValue("@month", dto.Month);
                cmd.Parameters.AddWithValue("@day", dto.Day);
                cmd.Parameters.AddWithValue("@workingHours", dto.WorkingHours);

                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public StampingDto GetAttendance(int employeeCode, int year, int month, int day)
        {
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping WHERE employeeCode = @employeeCode AND year = @year AND month = @month AND day= @day", conn))
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
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping", conn))
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
            using (SqlCommand cmd = new SqlCommand("SELECT year FROM Attendance.dbo.Stamping GROUP BY year", conn))
            {
                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return this.SetStampingDto(dt);
            }
        }

        public List<StampingDto> GetStampingMonths(int? selectedYear)
        {
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT month FROM Attendance.dbo.Stamping WHERE year = @year GROUP BY month", conn))
            {
                cmd.Parameters.AddWithValue("@year", selectedYear);

                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return this.SetStampingDto(dt);
            }
        }

        public List<StampingDto> GetTermStamping(int year1, int month1, int day1, int year2, int month2, int day2)
        {
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
