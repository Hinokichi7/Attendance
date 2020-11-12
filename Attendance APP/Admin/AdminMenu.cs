using Attendance_APP.Admin;
using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Windows.Forms;

namespace Attendance_APP
{
    public partial class AdminMenu : Form
    {

        public AdminMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            new NewRecord().ShowDialog(this);
        }



        private void EditRecord_Click(object sender, EventArgs e)
        {
            new EditRecord().ShowDialog(this);
        }
    }
}
