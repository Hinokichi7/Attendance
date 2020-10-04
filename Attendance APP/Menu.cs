using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Attendance_APP
{
    public partial class Menu : Form
    {
        private List<EmployeeDto> Tbl_employee { get; set; }

        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // cmbに設定(社員データ)
            this.SetEmployList(cmb_employee);
        }

        private void SetEmployList(ComboBox cmb)
        {
            // 社員を取得
            this.Tbl_employee = new EmployeeDao().GetAllEmployee();
            // cmbに設定・表示
            cmb.DataSource = this.Tbl_employee;
            cmb.ValueMember = "Code";
            cmb.DisplayMember = "Name";
        }

        private EmployeeDto GetSelectedEmployee() {
            return this.Tbl_employee.Find(employee => employee.Code == int.Parse(cmb_employee.SelectedValue.ToString()));
        }


        private void Stamping_Click(object sender, EventArgs e)
        {
            // 選択した社員ををStampingクラスへ渡す
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

        private void button1_Click(object sender, EventArgs e)
        {
            new AdminMenu().ShowDialog(this);
        }
    }
}
