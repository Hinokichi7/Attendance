using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_APP.Dao
{
    class Dao
    {
        private const string DATA_SOURCE = "DESKTOP-NS328PO";
        private const string USER_ID = "sa";
        private const string PASSWORD = "admin";
        private const string INITIAL_CATALOG = "master";

        private SqlConnectionStringBuilder GetStringBuilder()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = Dao.DATA_SOURCE;
            builder.UserID = Dao.USER_ID;
            builder.Password = Dao.PASSWORD;
            builder.InitialCatalog = Dao.INITIAL_CATALOG;
            return builder;
        }
        protected SqlConnection GetConnection()
        {
            var builder = this.GetStringBuilder();
            var connection = new SqlConnection(builder.ConnectionString);
            return connection;
        }
    }
}
