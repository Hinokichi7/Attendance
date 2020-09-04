namespace Attendance_APP.Dto
{
    public class EmployeeDto
    {
        private int _code;
        private string _name;
        private int _departmentCode;

        public int Code
        {
            get { return this._code; }
            set { this._code = value; }
        }
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public int DepartmentCode
        {
            get { return this._departmentCode; }
            set { this._departmentCode = value; }
        }
    }




}
