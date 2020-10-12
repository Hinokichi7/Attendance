using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Attendance_APP
{
    public partial class Menu : Form
    {

        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void Stamping_Click(object sender, EventArgs e)
        {
            var stamping = new Stamping();
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
