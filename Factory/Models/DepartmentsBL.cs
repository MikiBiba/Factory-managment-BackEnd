using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class DepartmentsBL
    {
        FactoryDBEntitie db = new FactoryDBEntitie();

        public List<DepWithManagerModel> getDepartments()
        {
            List<DepWithManagerModel> departments = new List<DepWithManagerModel>();

            foreach (var dep in db.Departments)
            {
                DepWithManagerModel newDep =  new DepWithManagerModel(); 
                
                newDep.ID = dep.ID; 
                newDep.Name = dep.Name;
                newDep.Employees = new List<Employee>();

                //
                var deps = db.Departments;

                foreach (var emp in db.Employees)
                {
                    var isManager = false;
                    foreach (var dep1 in deps)
                    {
                        if(dep1.Manager == emp.ID)
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

        public DepWithManagerModel getDepartment(int id)
        {
            return getDepartments().Where(x => x.ID == id).First();




        }

        public string AddDepartment(DepWithManagerModel dep)
        {
            Department newDep = new Department();

            newDep.Name = dep.Name;
            newDep.Manager = dep.Manager.ID;
           
            db.Departments.Add(newDep);

            db.SaveChanges();

            return "Created!";

        }

        public string UpdateDepartment(int id, DepWithManagerModel dep)
        {
            var resultDep = db.Departments.Where(x => x.ID == id).First();

            dep.Name = resultDep.Name;
            dep.Manager.ID = resultDep.Manager;

            db.SaveChanges();

            return "Updated!";

        }

        public string DeleteDepartment(int id)
        {
            var resultDep = db.Departments.Where(x => x.ID == id).First();

            db.Departments.Remove(resultDep);
            
            db.SaveChanges();

            return "Deleted!";

        }


    }
}