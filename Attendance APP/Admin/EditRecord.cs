using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Data;
using System.Windows.Forms;

namespace Attendance_APP.Admin
{
    public partial class EditRecord : Form
    {
        DataTable StampingTable { get; set; }
        //EmployeeDto Employee { get; set; }
        public EditRecord()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void serch_Click(object sender, EventArgs e)
        {
            var employee = cmbEmployee1.GetSelectedEmployee();
            var startPoint = cmbDate1.GetSelectedPoint();
            var endPoint = cmbDate2.GetSelectedPoint();
            if (employee != null && cmbDate1.GetSelectedDate() <= cmbDate2.GetSelectedDate())
            {
                this.StampingTable = new StampingDao().GetAllStamping(employee.Code, startPoint, endPoint);
                dataGridView1.DataSource = this.StampingTable;
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("打刻データがありません。");
                }
            }
            else
            {
                MessageBox.Show("検索条件が正しく選択されていません。");
            }
        }


        private void edit_Click_1(object sender, EventArgs e)
        {
            var x = new StampingDao().SetStampingDto(this.StampingTable);
            //foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            //{
                new EditRecordForm(cmbEmployee1.GetSelectedEmployee(),x[dataGridView1.SelectedRows[0].Index]).ShowDialog();
            //}
        }
    }
}
