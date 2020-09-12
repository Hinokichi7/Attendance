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
                if (dt.Columns.Contains("id"))
                {
                    dto.Id = int.Parse(dr["id"].ToString());
                }
                if (dt.Columns.Contains("createTime"))
                {
                    dto.CreateTime = DateTime.Parse(dr["createTime"].ToString());
                }
                if (dt.Columns.Contains("updateTime") && !String.IsNullOrEmpty(dr["updateTime"].ToString()))
                {
                    dto.UpdateTime = DateTime.Parse(dr["updateTime"].ToString());
                }
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
                if (dt.Columns.Contains("remark") && !String.IsNullOrEmpty(dr["remark"].ToString()))
                {
                    dto.Remark = dr["remark"].ToString();
                }
                list.Add(dto);
            }
            return list;
        }

        //public List<StampingDto> GetAllStamping()
        //{
        //    var dt = new DataTable();
        //    using (var conn = GetConnection())
        //    using (var cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping", conn))
        //    {
        //        conn.Open();
        //        var adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(dt);
        //        return this.SetStampingDto(dt);
        //    }
        //}

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
                if (this.SetStampingDto(dt).Count != 0)
                {
                return this.SetStampingDto(dt)[0];
                }
                else
                {
                    return null;
                }
            }
        }

        //public StampingDto GetAttendance(int employeeCode, int year, int month, int day)
        //{
        //    //社員、年月日からStampingテーブルの行データを指定して読み込み
        //    var dt = new DataTable();
        //    using (var conn = GetConnection())
        //    using (var cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping WHERE employeeCode = @employeeCode AND year = @year AND month = @month AND day= @day", conn))
        //    {

        //        cmd.Parameters.AddWithValue("@employeeCode", employeeCode);
        //        cmd.Parameters.AddWithValue("@year", year);
        //        cmd.Parameters.AddWithValue("@month", month);
        //        cmd.Parameters.AddWithValue("@day", day);

        //        conn.Open();
        //        var adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(dt);
        //        return this.SetStampingDto(dt)[0];
        //    }
        //}

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

        public List<StampingDto> GetTermStamping(string startPoint, string endPoint)
        {
            //年月日１から年月日２の期間からStampingテーブルの行データを指定して読み込み
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping WHERE attendance BETWEEN @startPoint AND @endPoint", conn))
            //using (SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping WHERE attendance >= startPoint AND attendance <= endPoint", conn))
            {
                cmd.Parameters.AddWithValue("@startPoint", startPoint);
                cmd.Parameters.AddWithValue("@endPoint", endPoint);
                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return this.SetStampingDto(dt);
            }
        }

        public void AddStamping(StampingDto dto)
        {
            // 社員コード、年月日、出勤時間、勤務種別を追加
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("INSERT INTO Attendance.dbo.Stamping(createTime, employeeCode, year, month, day, attendance, stampingCode, remark) VALUES(@createTime, @employeeCode,@year, @month, @day,@attendance,@stampingCode, @remark)", conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@createTime", dto.CreateTime);
                cmd.Parameters.AddWithValue("@employeeCode", dto.EmployeeCode);
                cmd.Parameters.AddWithValue("@year", dto.Year);
                cmd.Parameters.AddWithValue("@month", dto.Month);
                cmd.Parameters.AddWithValue("@day", dto.Day);
                cmd.Parameters.AddWithValue("@attendance", dto.Attendance);
                cmd.Parameters.AddWithValue("@stampingCode", dto.StampingCode);
                cmd.Parameters.AddWithValue("@remark", dto.Remark);

                cmd.ExecuteNonQuery();

            }
        }

        public void UpdateStamping(StampingDto dto)
        {
            // 社員を指定して退勤時刻、労働時間を更新
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("UPDATE Attendance.dbo.Stamping SET updateTime = @updateTime, leavingWork = @leavingWork, workingHours = @workingHours, remark = @remark WHERE id = @id", conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@id", dto.Id);
                cmd.Parameters.AddWithValue("@updateTime", dto.UpdateTime);
                cmd.Parameters.AddWithValue("@leavingWork", dto.LeavingWork);
                cmd.Parameters.AddWithValue("@workingHours", dto.WorkingHours);
                cmd.Parameters.AddWithValue("@remark", dto.Remark);

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
    }
}
