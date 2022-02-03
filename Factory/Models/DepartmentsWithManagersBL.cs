using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class DepartmentsWithManagersBL
    {
        FactoryDBEntities db = new FactoryDBEntities();

        public List<DepartmentsWithManagers> GetDepartments()
        {
            List<DepartmentsWithManagers> departments = new List<DepartmentsWithManagers>();

            foreach (var item in db.DepartmentsTbls)
            {
                DepartmentsWithManagers newDep = new DepartmentsWithManagers();

                newDep.ID = item.ID;
                newDep.Name = item.Name;               
               

                var mngr = db.EmployeesTbls.Where(x => x.ID == item.Manager).First();
                newDep.Manager = mngr;

                departments.Add(newDep);
            }
            return departments;


        
        }
    }
}