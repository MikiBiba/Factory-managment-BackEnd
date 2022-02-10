using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class EmployeeWithShiftsModel
    {
        public int ID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int Start_work_year { get; set; }
        public int DepartmentID { get; set; }

        public List<shift> Shifts { get; set; }

    }
}