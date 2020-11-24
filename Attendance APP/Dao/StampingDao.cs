using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Attendance_APP.Dao
{
    class StampingDao : Dao
    {
        public List<StampingDto> SetStampingDto(DataTable dt)
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
            // 期間(文字列で指定)データを取得
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Stamping WHERE attendance BETWEEN @startPoint AND @endPoint", conn))
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
            // 出勤打刻
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("INSERT INTO Attendance.dbo.Stamping (createTime, employeeCode, year, month, day, attendance, stampingCode) VALUES(@createTime, @employeeCode,@year, @month, @day,@attendance,@stampingCode)", conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@createTime", dto.CreateTime);
                cmd.Parameters.AddWithValue("@employeeCode", dto.EmployeeCode);
                cmd.Parameters.AddWithValue("@year", dto.Year);
                cmd.Parameters.AddWithValue("@month", dto.Month);
                cmd.Parameters.AddWithValue("@day", dto.Day);
                cmd.Parameters.AddWithValue("@attendance", dto.Attendance);
                cmd.Parameters.AddWithValue("@stampingCode", dto.StampingCode);

                cmd.ExecuteNonQuery();

            }
        }

        public void UpdateStamping(StampingDto dto)
        {
            // 退勤打刻
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("UPDATE Attendance.dbo.Stamping SET updateTime = @updateTime, leavingWork = @leavingWork, workingHours = @workingHours WHERE id = @id", conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@id", dto.Id);
                cmd.Parameters.AddWithValue("@updateTime", dto.UpdateTime);
                cmd.Parameters.AddWithValue("@leavingWork", dto.LeavingWork);
                cmd.Parameters.AddWithValue("@workingHours", dto.WorkingHours);

                cmd.ExecuteNonQuery();

            }
        }

        public void AddNewRecord(StampingDto dto)
        {
            // 新規追加(管理)
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("INSERT INTO Attendance.dbo.Stamping (createTime, employeeCode, year, month, day, attendance, leavingwork, stampingCode, workingHours, remark) VALUES(@createTime, @employeeCode, @year, @month, @day, @attendance, @leavingWork, @stampingCode, @workingHours, @remark)", conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@createTime", dto.CreateTime);
                cmd.Parameters.AddWithValue("@employeeCode", dto.EmployeeCode);
                cmd.Parameters.AddWithValue("@year", dto.Year);
                cmd.Parameters.AddWithValue("@month", dto.Month);
                cmd.Parameters.AddWithValue("@day", dto.Day);
                cmd.Parameters.AddWithValue("@attendance", dto.Attendance);
                cmd.Parameters.AddWithValue("@leavingWork", dto.LeavingWork);
                cmd.Parameters.AddWithValue("@stampingCode", dto.StampingCode);
                cmd.Parameters.AddWithValue("@workingHours", dto.WorkingHours);
                cmd.Parameters.AddWithValue("@remark", dto.Remark);

                cmd.ExecuteNonQuery();

            }
        }


        public DataTable GetAllStamping(int employeeCode, string startPoint, string endPoint)
        {
            // 社員を指定して最新の打刻データを読み込み
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("SELECT x.id, year, month, day, FORMAT(attendance, 'HH:mm') as attendance, FORMAT(leavingWork, 'HH:mm') as leavingWork, x.stampingCode, stampingName, workingHours, remark FROM Attendance.dbo.Stamping as x, Attendance.dbo.StampingType as y WHERE x.stampingCode = y.stampingCode AND employeeCode = @employeeCode AND attendance BETWEEN @startPoint AND @endPoint", conn))
            {
                cmd.Parameters.AddWithValue("@employeeCode", employeeCode);
                cmd.Parameters.AddWithValue("@startPoint", startPoint);
                cmd.Parameters.AddWithValue("@endPoint", endPoint);
                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }

        public void UpdateEditRecord(StampingDto dto)
        {
            // 更新(管理)
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("UPDATE Attendance.dbo.Stamping SET updateTime = @updateTime, year = @year, month = @month, day = @day, attendance = @attendance, leavingwork = @leavingwork, stampingCode = @stampingCode, workingHours = @workingHours, remark = @remark WHERE id = @id", conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@id", dto.Id);
                cmd.Parameters.AddWithValue("@updateTime", dto.UpdateTime);
                //cmd.Parameters.AddWithValue("@employeeCode", dto.EmployeeCode);
                cmd.Parameters.AddWithValue("@year", dto.Year);
                cmd.Parameters.AddWithValue("@month", dto.Month);
                cmd.Parameters.AddWithValue("@day", dto.Day);
                cmd.Parameters.AddWithValue("@attendance", dto.Attendance);
                cmd.Parameters.AddWithValue("@leavingWork", dto.LeavingWork);
                cmd.Parameters.AddWithValue("@stampingCode", dto.StampingCode);
                cmd.Parameters.AddWithValue("@workingHours", dto.WorkingHours);
                cmd.Parameters.AddWithValue("@remark", dto.Remark);

                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteRecord(StampingDto dto)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand("DELETE FROM  Attendance.dbo.Stamping WHERE @id = id", conn))
            {
                conn.Open();

                cmd.Parameters.AddWithValue("@id", dto.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
