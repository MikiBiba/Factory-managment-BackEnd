using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Factory.Models;

using System.Web.Http.Cors;

namespace Factory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public static EmployeeBL empBL = new EmployeeBL();
        public List<EmpExtendedModel> Get()
        {
            return empBL.getEmployees();
        }

        public EmpExtendedModel Get(int id)
        {
            return empBL.getEmployee(id);
        }

        // PUT: api/Employee/5
        public string Patch(int id, EmpExtendedModel dep)
        {
            return empBL.UpdateEmployee(id, dep);
        }

        // DELETE: api/Employee/5
        public string Delete(int id)
        {
            return empBL.DeleteEmployee(id);
        }
    }
}
