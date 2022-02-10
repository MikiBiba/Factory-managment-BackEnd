using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class DepWithManagerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Employee Manager { get; set; }
        public List<Employee> Employees { get; set;}

    }
}