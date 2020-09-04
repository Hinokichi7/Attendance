using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_APP.Dto
{
    class StampingTypeDto
    {
        private int _stampingCode;
        private string _stampingName;

        public int StampingCode
        {
            get { return this._stampingCode; }
            set { this._stampingCode = value; }
        }
        public string StampingName
        {
            get { return this._stampingName; }
            set { this._stampingName = value; }
        }
    }
}
