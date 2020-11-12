using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Attendance_APP.Dao;
using Attendance_APP.Dto;
using Attendance_APP.Admin;

namespace Attendance_APP
{
    public partial class CmbEmployee : UserControl
    {
        public event EventHandler StatusUpdated;
        private List<EmployeeDto> EmployeeList { get; set; }
        //public event EventHandler ComboBoxSelectionChangeCommitted;

        public CmbEmployee()
        {
            InitializeComponent();
            this.EmployeeList = new EmployeeDao().GetAllEmployee();
            this.SetCmbEmployee();
        }

        public void SetCmbEmployee()
        {
            cmb_employee.DataSource = new EmployeeDao().GetAllEmployee();
            cmb_employee.ValueMember = "Code";
            cmb_employee.DisplayMember = "Name";
            cmb_employee.SelectedIndex = -1;
        }
        public EmployeeDto GetSelectedEmployee()
        {
            if (cmb_employee.SelectedIndex == -1)
            {
                return null;
            }
            return this.EmployeeList.Find(employee => employee.Code == int.Parse(cmb_employee.SelectedValue.ToString()));
        }

        private void cmb_employee_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (this.StatusUpdated != null)
                this.StatusUpdated(this, new EventArgs());
            var employee = this.GetSelectedEmployee();
            if (employee != null)
            {
                departmentName.Text = new DepartmentDao().GetAllDepartment().Find(department => department.Code == employee.DepartmentCode).Name;
            }
        }
    }
}
