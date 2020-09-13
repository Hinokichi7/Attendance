using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_APP.Dao
{
    class DepartmentDao : Dao
    {
        public List<DepartmentDto> GetAllDepartment()
        {
        var list = new List<DepartmentDto>();
        var dt = new DataTable();
        using (var conn = GetConnection())
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance.dbo.Department", conn))
            {
                conn.Open();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    var dto = new DepartmentDto();
                    dto.Code = int.Parse(dr["code"].ToString());
                    dto.Name = dr["name"].ToString();

                    list.Add(dto);
                }
                return list;
            }
        }
    }
}
