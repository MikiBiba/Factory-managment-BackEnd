using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class DepartmentsBL
    {
        FactoryDBEntitie db = new FactoryDBEntitie();

        public List<DepExtendedModel> getDepartments()
        {
            List<DepExtendedModel> departments = new List<DepExtendedModel>();

            foreach (var dep in db.Departments)
            {
                DepExtendedModel newDep =  new DepExtendedModel(); 
                
                newDep.ID = dep.ID; 
                newDep.Name = dep.Name;
                newDep.Employees = new List<Employee>();

                //Searching for employees that are not managers
                var deps = db.Departments;

                foreach (var emp in db.Employees)
                {
                    var isManager = false;
                    foreach (var dep1 in deps)
                    {
                        if (dep1.Manager == emp.ID)
                        {
                            isManager = true;
                        }
                    }
                    if (!isManager)
                    {
                        newDep.Employees.Add(emp);
                    }                 
                }

                var mngr = db.Employees.Where(x => x.ID == dep.Manager).First();

                newDep.Manager = mngr;

                departments.Add(newDep);            
            }
            return departments;
        }

        public DepExtendedModel getDepartment(int id)
        {
            return getDepartments().Where(x => x.ID == id).First();
        }

        public string AddDepartment(DepExtendedModel dep)
        {
            Department newDep = new Department();

            newDep.Name = dep.Name;
            newDep.Manager = dep.Manager.ID;
           
            db.Departments.Add(newDep);

            db.SaveChanges();

            var emp = db.Employees.Where(x => x.ID == newDep.Manager).First();
            emp.DepartmentID = newDep.ID;

            db.SaveChanges();

            return "Created!";
        }

        public string UpdateDepartment(int id, DepExtendedModel dep)
        {
            var resultDep = db.Departments.Where(x => x.ID == id).First();

            resultDep.Name = dep.Name;
            resultDep.Manager = dep.Manager.ID;


            db.SaveChanges();

            return "Updated!";
        }

        public string DeleteDepartment(int id)
        {

            foreach (var item in db.Employees)
            {
                if(item.DepartmentID == id)
                {
                    return "You can't delete department with registered employees!";
                }
            }
            var resultDep = db.Departments.Where(x => x.ID == id).First();

            db.Departments.Remove(resultDep);

            db.SaveChanges();

            return "Deleted!";
        }
    }
}