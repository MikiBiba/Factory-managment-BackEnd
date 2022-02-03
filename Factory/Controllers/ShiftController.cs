using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Factory.Models;



namespace Factory.Controllers
{
    public class ShiftController : ApiController
    {
        // GET: api/Shift
        private static  ShiftBL shfBL = new ShiftBL();
        public List<Shift> Get()
        {
            return shfBL.GetShifts();
        }

        // GET: api/Shift/5
        public Shift Get(int id)
        {
            return shfBL.GetShift(id);
        }

        // POST: api/Shift
        public string Post(Shift shft)
        {
            return shfBL.AddShift(shft);
        }
    }
}
