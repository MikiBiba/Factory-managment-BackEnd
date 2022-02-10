using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class ShiftsWithEmployeesModel
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public int Start_time { get; set; }
        public int End_time { get; set; }
        public List<Employee> Employees { get; set;}
    }
}