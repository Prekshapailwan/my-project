using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Interface
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(string id);
        int AddEmployee(EmployeeDto employee);
        int UpdateEmployee(string id, EmployeeDto employee);
        int DeleteEmployee(string EmpId);
        List<Employee>  GetDepartmentById(int id);
        public List<Employee> LastUpdatedEmployees();
        public List<object> GetCountOfEmployeeByDepartment();
        public List<Employee> GetTopSalariesEmployeesDepartment(int count);

        public void ObjectToString();

        public bool FNamevalidation(string Fname);
        public bool LNamevalidation(string Lname);

        public bool Phonevalidation(string phone);
        //public int InsertData();

    }
}
