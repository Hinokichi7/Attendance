using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Attendance_APP.Dto;
using Attendance_APP.Dao;

namespace Attendance_APP.Contorol
{
    public partial class CmbStampingType : UserControl
    {
        private List<StampingTypeDto> StampingTypeList { get; set; }

        public CmbStampingType()
        {
            InitializeComponent();
            this.SetCmbStampingType();
            this.StampingTypeList = new StampingTypeDao().GetAllStampingType();
        }

        public void SetCmbStampingType()
        {
            cmb_stampingType.DataSource = new StampingTypeDao().GetAllStampingType();
            cmb_stampingType.ValueMember = "StampingCode";
            cmb_stampingType.DisplayMember = "StampingName";
            //cmb_stampingType.SelectedIndex = -1;
        }

        public StampingTypeDto GetSelectedStampingType()
        {
            if (cmb_stampingType.SelectedIndex == -1)
            {
                return null;
            }
            return this.StampingTypeList.Find(stampingType => stampingType.StampingCode == int.Parse(cmb_stampingType.SelectedValue.ToString()));
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.GetSelectedStampingType();
        }

        public void GetSelectedValue2(StampingDto stamping)
        {
            cmb_stampingType.Text = this.StampingTypeList.Find(stampingType => stampingType.StampingCode == stamping.StampingCode).StampingName;
        }
    }
}
