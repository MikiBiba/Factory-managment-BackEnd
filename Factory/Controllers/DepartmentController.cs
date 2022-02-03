using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Factory.Models;

namespace Factory.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET: api/Department
        private static DepartmentBL depBL = new DepartmentBL();
        public List<DepartmentsTbl> Get()
        {
            return depBL.GetDepartments();
        }

        // GET: api/Department/5
        public DepartmentsTbl Get(int id)
        {
            return depBL.getDepartment(id);
        }

        // POST: api/Department
        public string Post(DepartmentsTbl dep)
        {
            return depBL.AddDepartment(dep);
        }

        // PUT: api/Department/5
        public string Put(int id, DepartmentsTbl dep)
        {
            return depBL.UpdateDepartment(id, dep);
        }

        // DELETE: api/Department/5
        public string Delete(int id)
        {
            return depBL.DeleteDepartment(id);  
        }
    }
}
