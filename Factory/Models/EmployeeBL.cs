using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class EmployeeBL
    {
        FactoryDBEntities db = new FactoryDBEntities();

        public List<EmployeesTbl> GetEmployees()
        {
            return db.EmployeesTbls.ToList();
        }


        public EmployeesTbl GetEmployee(int id)
        {
            return db.EmployeesTbls.Where(x => x.ID == id).First();
        }

        public string AddEmployee(EmployeesTbl emp)
        {
            db.EmployeesTbls.Add(emp);

            db.SaveChanges();

            return "Created";


        }

        public string UpdateEmployee(int id, EmployeesTbl emp)
        {
            var emp1 = db.EmployeesTbls.Where(x => x.ID == id).First();

            emp1.ID = emp.ID;
            emp1.First_name = emp.First_name;
            emp1.Last_name = emp.Last_name;
            emp1.Start_work_year = emp.Start_work_year;
            emp1.DepartmentID = emp.DepartmentID;

            db.SaveChanges();

            return "Updated";

        }

        public string DeleteEmployee(int id)
        {
            var e = db.EmployeesTbls.Where(x => x.ID == id).First();
            db.EmployeesTbls.Remove(e);

            db.SaveChanges();
            return "Deleted";
        }

    }
}