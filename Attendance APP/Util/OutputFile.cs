using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Attendance_APP.Util
{
    class OutputFile
    {
        public void WriteCsv(string fileName, bool append, List<StampingDto> Stampinglists)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append))
            {
                Stampinglists.ForEach((StampingDto dto) =>
                {
                    sw.WriteLine(
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}",
                        dto.CreateTime,
                        dto.UpdateTime,
                        dto.EmployeeCode,
                        dto.Year,
                        dto.Month,
                        dto.Day,
                        dto.Attendance,
                        dto.LeavingWork,
                        dto.StampingCode,
                        dto.WorkingHours,
                        dto.Remark
                        );
                });
            }
        }

        public void SaveFileDialog(string startPoint, string endPoint)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "attendance.csv";
            sfd.InitialDirectory = @"C:\Users\user\Desktop\test";
            sfd.Filter = "TXTファイル|*.txt|CSVファイル|*.csv|すべてのファイル|*.*";
            sfd.FilterIndex = 2;
            sfd.Title = "保存先のファイルを選択してください";



            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                var Stampinglists = new StampingDao().GetTermStamping(startPoint, endPoint);
                Console.WriteLine($"{sfd.FileName}{Stampinglists}");
                this.WriteCsv(sfd.FileName, false, Stampinglists);
            }
        }
    }
}
