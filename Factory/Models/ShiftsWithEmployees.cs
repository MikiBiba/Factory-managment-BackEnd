using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class ShiftsWithEmployees
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public int Start_time { get; set; }
        public int End_time { get; set; }
        public List<EmployeesTbl> Employees { get; set; }
    }
}