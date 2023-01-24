using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_11
{
    public class Department
    {
        public string DepartmentName { get; set; }
        public int DepartmentID { get; set; }

        public Department(string DepartmentName, int DepartmentID)
        {
            this.DepartmentName = DepartmentName;
            this.DepartmentID = DepartmentID;
        }

        public override string ToString() //формат вывода департамента
        {
            return $"{DepartmentName} {DepartmentID}";
        }
    }
}
