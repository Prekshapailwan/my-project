using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interface;
using Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService() {

            string json = File.ReadAllText("employee.json");

            var newemp = JsonConvert.DeserializeObject<List<Employee>>(json);

            empDeserialize.AddRange(newemp);


            _employees = empDeserialize;
        }
        public bool FNamevalidation(string Fname)
        {
            string patterns = "^[a-zA-Z]+$";
            if (Fname!= null)
            {
                return Regex.IsMatch(Fname, patterns);
            }
            return false;
        }
        public bool LNamevalidation(string Lname)
        {
            string patterns = "^[a-zA-Z]+$";
            if (Lname!= null)
            {
                return Regex.IsMatch(Lname, patterns);
            }
            return false;
        }
        public bool Phonevalidation(string phone)
        {
            string pattern = "^\\d{10}$";
            if (phone!= null)
            {
                return Regex.IsMatch(phone, pattern);
            }
            return false;
        }

        public static  List<Employee> _employees = new List<Employee>();
        public List<Employee> empDeserialize = new List<Employee>();
        

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }
        public Employee GetEmployeeById(string id)
        {
            return _employees.FirstOrDefault(e => e.EmpID == id);
        }

        public List<Employee> GetDepartmentById(int id ) 
        {
            return _employees.Where(emp => emp.Department==(Dept)id).ToList();
        }
        /* public int GetCountOfEmployeeByDepartment(int DeptId)
         {
             return _employees.Count(emp => (int)emp.Department == DeptId);
         }*/
        public List<object> GetCountOfEmployeeByDepartment()
        {
            var CountDept = _employees.GroupBy(emp => emp.Department).Select(group => new 
            {                            
                Department = group.Key,
                EmpCount = group.Count()
            }).ToList<object>();
            return CountDept;
        }
        public List<Employee> LastUpdatedEmployees()
        {
           // return _employees.Where(e => e.Cureent >= fromDate).ToList();
            return GetAllEmployees().OrderByDescending(e => e.CreatedOn).Take(5).ToList();
        }




        public int AddEmployee(EmployeeDto employee)
        {
            Employee emp = new Employee(employee);
            
            _employees.Add(emp);

            ObjectToString();
            return 1;
        }
        public int UpdateEmployee(string id, EmployeeDto updatedEmployee)
        {
            Employee employeeToUpdate = _employees.FirstOrDefault(e => e.EmpID == id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = updatedEmployee.FirstName;  
                employeeToUpdate.LastName = updatedEmployee.LastName;
                employeeToUpdate.MiddleName = updatedEmployee.MiddleName;
                employeeToUpdate.Age = updatedEmployee.age;
                employeeToUpdate.Salary = updatedEmployee.salary;
                employeeToUpdate.Department = updatedEmployee.Department;
            }
            return 1;
        }
        public int DeleteEmployee(string EmpId)
        {
            var employeeToDelete = _employees.FirstOrDefault(e => e.EmpID == EmpId);
            _employees.Remove(employeeToDelete);
            
            ObjectToString();
            return 1;

        }
        public List<Employee> GetTopSalariesEmployeesDepartment(int count)
        {
            var Top = _employees.GroupBy(e => e.Department);
            List<Employee> retuenemp = new List<Employee>();
            foreach (var a in Top)
            {
                List<Employee> employees = a.OrderByDescending(a => a.Salary).Take(count).ToList();
                retuenemp.AddRange(employees);
            }
          
            return retuenemp;

        }
         
        public void ObjectToString()
        {
            string str = JsonConvert.SerializeObject(_employees);
            File.WriteAllText(@"employee.json", str);
        }

       /* public int InsertData()
        {
            throw new NotImplementedException();
        }*/
    }
}
