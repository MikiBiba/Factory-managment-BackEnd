using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class DepartmentsWithManagers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public EmployeesTbl Manager { get; set; }
    }
}