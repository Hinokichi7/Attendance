﻿using Attendance_APP.Dto;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Attendance_APP.Dao
{
    class StampingTypeDao : Dao
    {
        public List<StampingTypeDto> GetAllStampingType()
        {
            var list = new List<StampingTypeDto>();
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = "SELECT * FROM Attendance.dbo.StampingType";
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    var dto = new StampingTypeDto
                    {
                        StampingCode = int.Parse(dr["stampingCode"].ToString()),
                        StampingName = dr["stampingName"].ToString()
                    };
                    list.Add(dto);
                }
                return list;
            }
        }
    }
}
