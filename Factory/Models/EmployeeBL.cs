using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class EmployeeBL
    {
        FactoryDBEntitie db = new FactoryDBEntitie();
        public List<EmpExtendedModel> getEmployees()
        {
            List<EmpExtendedModel> employees = new List<EmpExtendedModel>();

            foreach (var emp in db.Employees)
            {
                EmpExtendedModel newEmployeeModel = new EmpExtendedModel();

                newEmployeeModel.ID = emp.ID;
                newEmployeeModel.First_name = emp.First_name;
                newEmployeeModel.Last_name = emp.Last_name;
                newEmployeeModel.Start_work_year = emp.Start_work_year;
                newEmployeeModel.DepartmentID = emp.DepartmentID;
                newEmployeeModel.Shifts = new List<shift>();
                newEmployeeModel.Departments = new List<Department>();
                

                //searching for all employee shifts
                var ShiftsRegistered = db.EmployeeShifts.Where(x => x.EmployeeID == emp.ID);

                foreach (var item in ShiftsRegistered)
                {
                    var shiftID = item.ShiftID;
                    var RegisteredShift = db.shifts.Where(x => x.ID == shiftID).First();
                    newEmployeeModel.Shifts.Add(RegisteredShift);
                }
                employees.Add(newEmployeeModel);

                //searching for all employee departments
                var dep = db.Departments.Where(x => x.ID == emp.DepartmentID).First();
                newEmployeeModel.Departments.Add(dep);

                //serching for employee's department name



            }
            return employees;
        }

        public EmpExtendedModel getEmployee(int id)
        {
            return getEmployees().Where(x => x.ID == id).First();
        }


        public string UpdateEmployee(int id, EmpExtendedModel emp)
        {
            var resultEmp = db.Employees.Where(x => x.ID == id).First();

            emp.ID = emp.ID;
            resultEmp.First_name = emp.First_name;
            resultEmp.Last_name = emp.Last_name;
            resultEmp.Start_work_year = emp.Start_work_year;

           var dep = db.Departments.Where(x => x.Name == emp.DepName).First();

            resultEmp.DepartmentID = dep.ID;

            db.SaveChanges();

            return "Updated!";
        }

        public string DeleteEmployee(int id)
        {


            foreach (var item in db.Departments)
            {
                if (item.Manager == id)
                {
                    return "This Employee is manager, please switch manager first!";
                }
                else
                {
                    var resultEmp = db.Employees.Where(x => x.ID == id).First();

                    db.Employees.Remove(resultEmp);

                    foreach (var emp in db.EmployeeShifts)
                    {

                        if (emp.EmployeeID == id)
                        {
                            db.EmployeeShifts.Remove(emp);
                        }
                    }
                }
            }

            db.SaveChanges();

           return "Deleted!"; 
        }
    }
}