using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_APP
{
    class SetCmbDate
    {
        public void SetCmbBox(ComboBox cmb, List<StampingDto> list, String DisplayMember, String ValueMember)
        {
            cmb.DataSource = list;
            cmb.ValueMember = ValueMember;
            cmb.DisplayMember = DisplayMember;
            cmb.SelectedIndex = 0;
        }

        // 1からmaxまでの数値をcmb.Itemに追加
        public void SetCmbBox(ComboBox cmb, int max)
        {
            for (var i = 1; i <= max; i++)
            {
                cmb.Items.Add(i);
            }
            cmb.SelectedIndex = 0;
        }

        // 日付候補を取得
        public void SetCmbBoxDay(ComboBox cmb_year, ComboBox cmb_month, ComboBox cmb_day)
        {
            if (cmb_year.SelectedValue != null && cmb_month.SelectedItem != null)
            {
                cmb_day.Items.Clear();
                var maxDay = DateTime.DaysInMonth((int)cmb_year.SelectedValue, (int)cmb_month.SelectedItem);

                SetCmbBox(cmb_day, maxDay);
            }
        }
    }

}
