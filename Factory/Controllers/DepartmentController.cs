using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Cors;

using Factory.Models;

namespace Factory.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DepartmentController : ApiController
    {

        DepartmentsBL depBL = new DepartmentsBL();
        // GET: api/Department
        public List<DepExtendedModel> Get()
        {
            return depBL.getDepartments();
        }

        // GET: api/Department/5
        public DepExtendedModel Get(int id)
        {
            return depBL.getDepartment(id);
        }

        // POST: api/Department
        public string Post(DepExtendedModel dep)
        {
            return depBL.AddDepartment(dep);    
        }

        // PUT: api/Department/5
        public string Patch(int id, DepExtendedModel dep)
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
