using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Attendance_APP.Admin
{
    public partial class EditRecord : Form
    {
        DataTable StampingTable { get; set; }
        DataGridViewSelectedRowCollection SelectedRows { get; set; }
        public EditRecord()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }


        private void SetGredView()
        {
            var employee = cmbEmployee1.GetSelectedEmployee();
            var startPoint = cmbDate1.GetSelectedPoint();
            var endPoint = cmbDate2.GetSelectedPoint();
            if (employee != null && cmbDate1.GetSelectedDate() <= cmbDate2.GetSelectedDate())
            {
                this.StampingTable = new StampingDao().GetAllStamping(employee.Code, startPoint, endPoint);
                dataGridView1.DataSource = this.StampingTable;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "HH:mm";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "HH:mm";

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

        private void serch_Click(object sender, EventArgs e)
        {
            this.SetGredView();
        }

        private void edit_Click_1(object sender, EventArgs e)
        {
            var stamping = new StampingDao().SetStampingDto(this.StampingTable);
            this.SelectedRows = dataGridView1.SelectedRows;
            if(this.SelectedRows.Count == 1)
            {
                var editRecordForm = new EditRecordForm(cmbEmployee1.GetSelectedEmployee(),stamping[this.SelectedRows[0].Index]);
                if (System.Windows.Forms.DialogResult.OK == editRecordForm.ShowDialog())
                {
                    this.SetGredView();
                }
            }
            else
            {
                MessageBox.Show("編集する打刻レコードを1行選択してください。");
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {

            var stamping = new StampingDao().SetStampingDto(this.StampingTable);
            this.SelectedRows = dataGridView1.SelectedRows;
            string message = "";
            StampingDto selectedStamping = null;
            if (this.SelectedRows.Count != 0)
            {
                for (var i = 0; i < this.SelectedRows.Count; i++)
                {
                    selectedStamping = stamping[this.SelectedRows[i].Index];
                    message += "\n" + selectedStamping.Attendance.ToString("yyyy/MM/dd");
                }

                DialogResult result = MessageBox.Show(message + "のレコードを削除します。", "", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    for (var i = 0; i < this.SelectedRows.Count; i++)
                    {
                        selectedStamping = stamping[this.SelectedRows[i].Index];
                        new StampingDao().DeleteRecord(selectedStamping);
                    }
                }
                this.SetGredView();
            }


        }
    }
}
