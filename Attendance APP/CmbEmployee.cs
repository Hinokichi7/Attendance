using Attendance_APP.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_APP
{
    class CmbEmployee:ComboBox
    {
        public CmbEmployee()
        {
            this.DataSource = new EmployeeDao().GetAllEmployee();
            this.ValueMember = "Code";
            this.DisplayMember = "Name";
            this.SelectedIndex = -1;
        }
    }
}
