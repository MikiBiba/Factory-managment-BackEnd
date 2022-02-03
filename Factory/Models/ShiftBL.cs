using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class ShiftBL
    {

        FactoryDBEntities db = new FactoryDBEntities();

        public List<Shift> GetShifts()
        {
            return db.Shifts.ToList();
        }


        public Shift GetShift(int id)
        {
            return db.Shifts.Where(x => x.ID == id).First();
        }

        public string AddShift(Shift shft)
        {
            db.Shifts.Add(shft);

            db.SaveChanges();

            return "Created";


        }

    }
}