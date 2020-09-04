using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Attendance_APP
{
    public partial class Menu : Form
    {
        private List<EmployeeDto> list;

        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SetEmployList();
            this.AddListItem();
        }


        private void AddListItem()
        {
            comboBox1.DataSource = list;
            comboBox1.ValueMember = "Code";
            comboBox1.DisplayMember = "Name";
        }
        private void SetEmployList() {
            this.list = new EmployeeDao().GetAllEmployee();
        }

        private EmployeeDto GetSelectedEmployee() {
            return list.Find(employee => employee.Code == int.Parse(comboBox1.SelectedValue.ToString()));
        }


        private void Stamping_Click(object sender, EventArgs e)
        {
            var employee = GetSelectedEmployee();
            var stamping = new Stamping(employee);
            stamping.ShowDialog(this);
        }

        private void End_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void outputCsv_Click(object sender, EventArgs e)
        {
            var csvOutput = new ForOutput();
            csvOutput.ShowDialog(this);
        }
    }
}
