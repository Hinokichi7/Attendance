using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_APP.Dto
{
    public class StampingDto
    {
        private int _employeeCode;
        private int _year;
        private int _month;
        private int _day;
        private DateTime _attendance;
        private DateTime _leavingWork;
        private int _stampingCode;
        private double _workingHours;

        public int EmployeeCode
        {
            get { return this._employeeCode; }
            set { this._employeeCode = value; }
        }
        public int Year
        {
            get { return this._year; }
            set { this._year = value; }
        }
        public int Month
        {
            get { return this._month; }
            set { this._month = value; }
        }
        public int Day
        {
            get { return this._day; }
            set { this._day = value; }
        }
        public DateTime Attendance
        {
            get { return this._attendance; }
            set { this._attendance = value; }
        }
        public DateTime LeavingWork
        {
            get { return this._leavingWork; }
            set { this._leavingWork = value; }
        }
        public int StampingCode
        {
            get { return this._stampingCode; }
            set { this._stampingCode = value; }
        }
        public double WorkingHours
        {
            get { return this._workingHours; }
            set { this._workingHours = value; }
        }
    }
}
