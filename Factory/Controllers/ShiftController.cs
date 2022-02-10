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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShiftController : ApiController
    {
        // GET: api/Shift
        public static ShiftsBL shBL  = new ShiftsBL();
        public List<ShiftsWithEmployeesModel> Get()
        {
            return shBL.getShifts();
        }

        public ShiftsWithEmployeesModel Get(int id)
        {
            return shBL.getShift(id);
        }

        // POST: api/Shift/5
        public string Post(ShiftsWithEmployeesModel shift)
        {
             return shBL.AddShift(shift);
        }

    }

    
}
