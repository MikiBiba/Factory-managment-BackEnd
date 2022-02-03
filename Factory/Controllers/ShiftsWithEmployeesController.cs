using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Factory.Models;

namespace Factory.Controllers
{
    public class ShiftsWithEmployeesController : ApiController
    {
        ShiftsWithEmployeesBL seBL = new ShiftsWithEmployeesBL();

        // GET: api/ShiftsWithEmployees
        public List<ShiftsWithEmployees> Get()
        {
            return seBL.GetShifts();
        }

        // GET: api/ShiftsWithEmployees/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShiftsWithEmployees
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShiftsWithEmployees/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShiftsWithEmployees/5
        public void Delete(int id)
        {
        }
    }
}
