using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class ShiftsWithEmployeesBL
    {
        FactoryDBEntities db = new FactoryDBEntities();
        public List<ShiftsWithEmployees> GetShifts()
        {
            List<ShiftsWithEmployees> shifts = new List<ShiftsWithEmployees>();

            foreach (var item in db.Shifts)
            {
                ShiftsWithEmployees shift = new ShiftsWithEmployees();
                
                shift.ID = item.ID; 
                shift.Date = item.Date; 
                shift.Start_time = item.Start_time;
                shift.End_time = item.End_time;
                shift.Employees = new List<EmployeesTbl>();

                var result = db.EmployeeShifts.Where(x => x.ShiftID == item.ID);

                foreach (var connect in result)
                {
                    var empId = connect.EmployeeID;
                    var emp = db.EmployeesTbls.Where(x => x.ID == empId).First();   
                    shift.Employees.Add(emp);
                }

                shifts.Add(shift);


            }
            return shifts;
        }
    }
}