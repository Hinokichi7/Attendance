using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_APP.Util
{
    class SelectEmployee
    {
        //private ComboBox Cmb_employee { get; set; }
        private List<EmployeeDto> EmployeeList { get; set; }

        public SelectEmployee(ComboBox cmb_employee)
        {
            //this.Cmb_employee = cmb_employee;
            this.EmployeeList = new EmployeeDao().GetAllEmployee();
            this.SetCmbEmployee(cmb_employee);
        }
        public void SetCmbEmployee(ComboBox cmb_employee)
        {
            cmb_employee.DataSource = new EmployeeDao().GetAllEmployee();
            cmb_employee.ValueMember = "Code";
            cmb_employee.DisplayMember = "Name";
            cmb_employee.SelectedIndex = -1;
        }
        public EmployeeDto GetSelectedEmployee(ComboBox cmb_employee)
        {
            if (cmb_employee.SelectedIndex == -1)
            {
                return null;
            }
            return this.EmployeeList.Find(employee => employee.Code == int.Parse(cmb_employee.SelectedValue.ToString()));
        }

        private void cmb_employee_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            //this.GetSelectedEmployee();
        }
    }
}
