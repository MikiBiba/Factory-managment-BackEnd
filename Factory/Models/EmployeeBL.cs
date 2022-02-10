using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class EmployeeBL
    {
        FactoryDBEntitie db = new FactoryDBEntitie();
        public List<EmployeeWithShiftsModel> getEmployees()
        {
            List<EmployeeWithShiftsModel> employees = new List<EmployeeWithShiftsModel>();

            foreach (var emp in db.Employees)
            {
                EmployeeWithShiftsModel newEmployeeModel = new EmployeeWithShiftsModel();

                newEmployeeModel.ID = emp.ID;
                newEmployeeModel.First_name = emp.First_name;
                newEmployeeModel.Last_name = emp.Last_name;
                newEmployeeModel.Start_work_year = emp.Start_work_year;
                newEmployeeModel.DepartmentID = emp.DepartmentID;
                newEmployeeModel.Shifts = new List<shift>();

                var ShiftsRegistered = db.EmployeeShifts.Where(x => x.EmployeeID == emp.ID);

                foreach (var item in ShiftsRegistered)
                {
                    var shiftID = item.ShiftID;
                    var RegisteredShift = db.shifts.Where(x => x.ID == shiftID).First();
                    newEmployeeModel.Shifts.Add(RegisteredShift);
                }
                employees.Add(newEmployeeModel);
            }
            return employees;
        }

        public EmployeeWithShiftsModel getEmployee(int id)
        {
            return getEmployees().Where(x => x.ID == id).First();
        }


        public string UpdateEmployee(int id, EmployeeWithShiftsModel emp)
        {
            var resultEmp = db.Employees.Where(x => x.ID == id).First();

            emp.ID = resultEmp.ID;
            emp.First_name = resultEmp.First_name;
            emp.Last_name = resultEmp.Last_name;
            emp.DepartmentID = resultEmp.DepartmentID;

            db.SaveChanges();

            return "Updated!";
        }

        public string DeleteEmployee(int id)
        {
            var resultEmp = db.Employees.Where(x => x.ID == id).First();

            db.Employees.Remove(resultEmp);

            foreach (var item in db.EmployeeShifts)
            {

                if (item.EmployeeID == id)
                {
                    db.EmployeeShifts.Remove(item);
                }
            }

            db.SaveChanges();

            return "Deleted!";

        }
    }
}