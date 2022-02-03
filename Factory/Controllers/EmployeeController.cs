using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Factory.Models;

namespace Factory.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        private static EmployeeBL empBL = new EmployeeBL();
        public List<EmployeesTbl> Get()
        {
            return empBL.GetEmployees();
        }

        // GET: api/Employee/5
        public EmployeesTbl Get(int id)
        {
            return empBL.GetEmployee(id);
        }

        // POST: api/Employee
        public string Post(EmployeesTbl emp)
        {
            return empBL.AddEmployee(emp);
        }

        // PUT: api/Employee/5
        public string Put(int id, EmployeesTbl emp)
        {
            return empBL.UpdateEmployee(id, emp);
        }

        // DELETE: api/Employee/5
        public string Delete(int id)
        {
            return empBL.DeleteEmployee(id);
        }
    }
}
