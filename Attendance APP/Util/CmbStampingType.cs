using Attendance_APP.Dao;
using Attendance_APP.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_APP.Util
{
    class CmbStampingType
    {
        public void SetComBox(ComboBox cmb)
        {
            cmb.DataSource = new StampingTypeDao().GetAllStampingType();
            cmb.ValueMember = "StampingCode";
            cmb.DisplayMember = "StampingName";
        }
        public StampingTypeDto GetSelectedStampingType(ComboBox cmb)
        {
            return new StampingTypeDao().GetAllStampingType().Find(stampingType => stampingType.StampingCode == int.Parse(cmb.SelectedValue.ToString()));
        }
    }
}
