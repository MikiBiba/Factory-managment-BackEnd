using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class DepartmentBL
    {
        FactoryDBEntities db = new FactoryDBEntities();

        public List<DepartmentsTbl> GetDepartments()
        {
            return db.DepartmentsTbls.ToList();
        }
        

        public DepartmentsTbl getDepartment(int id)
        {
            return db.DepartmentsTbls.Where(x => x.ID == id).First();
        }

        public string AddDepartment(DepartmentsTbl dep)
        {
            db.DepartmentsTbls.Add(dep);

            db.SaveChanges();

            return "Created";


        }

        public string UpdateDepartment(int id, DepartmentsTbl dep)
        {
            var dep1 = db.DepartmentsTbls.Where(x => x.ID == id).First();

            dep1.Name = dep.Name;
            dep1.ID = dep.ID;
            dep1.Manager = dep.Manager;

            db.SaveChanges();

            return "Updated";

        }

        public string DeleteDepartment(int id)
        {
            var d = db.DepartmentsTbls.Where(x => x.ID == id).First();
            db.DepartmentsTbls.Remove(d);

            db.SaveChanges();
            return "Deleted";
        }



    }
}