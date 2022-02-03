using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Factory.Models;

namespace Factory.Controllers
{
    public class DepartmentWithManagersController : ApiController
    {
        DepartmentsWithManagersBL dmBL = new DepartmentsWithManagersBL();

        // GET: api/DepartmentWithManagers
        public List<DepartmentsWithManagers> Get()
        {
            return dmBL.GetDepartments();
        }

        // GET: api/DepartmentWithManagers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DepartmentWithManagers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DepartmentWithManagers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DepartmentWithManagers/5
        public void Delete(int id)
        {
        }
    }
}
