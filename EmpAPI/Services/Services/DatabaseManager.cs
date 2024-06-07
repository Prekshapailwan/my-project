using Microsoft.Data.SqlClient;
using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Services.Services
{
    public class DatabaseManager : IEmployeeService
    {
        private readonly string _connectionString = @"Data Source = 192.168.10.28\SQLEX2017;Initial Catalog=Preksha; User Id=sysfore.ea;Password=Sys@2024#;Encrypt=false";

        public int AddEmployee(EmployeeDto employee)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            Employee emp = new Employee(employee);
            string insrtQuery = "Insert into Employees(EmployeeID,FirstName, MiddleName, LastName, Phone, salary, Age,Department) values (@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8)";
            
            SqlCommand command = new SqlCommand(insrtQuery, connection);
            command.Parameters.AddWithValue("@value1", emp.EmpID);
            command.Parameters.AddWithValue("@value2", emp.FirstName);
            command.Parameters.AddWithValue("@value3", emp.MiddleName);
            command.Parameters.AddWithValue("@value4", emp.LastName);
            command.Parameters.AddWithValue("@value5", emp.Phone);
            command.Parameters.AddWithValue("@value6", emp.Salary);
            command.Parameters.AddWithValue("@value7", emp.Age);
            command.Parameters.AddWithValue("@value8",(int) emp.Department);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
           
        }

        public int DeleteEmployee(string EmpID)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            string deleteQuery = "Delete Employees where EmployeeID =@value1";
            SqlCommand command = new SqlCommand(deleteQuery, connection);
            command.Parameters.AddWithValue("@value1",new Guid(EmpID));
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }

        public int UpdateEmployee(string id, EmployeeDto employee)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            Employee emp = new Employee(employee);
            string updateQuery = "update Employees set FirstName = @value1,MiddleName = @value2,LastName = @value3,Phone  = @value4, salary = @value5, Age  = @value6,Department  = @value7   where EmployeeID=@value8";
            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@value1",emp.FirstName );
            command.Parameters.AddWithValue("@value2", emp.MiddleName);
            command.Parameters.AddWithValue("@value3", emp.LastName);
            command.Parameters.AddWithValue("@value4", emp.Phone);
            command.Parameters.AddWithValue("@value5", emp.Salary);
            command.Parameters.AddWithValue("@value6", emp.Age);
            command.Parameters.AddWithValue("@value7",(int) emp.Department);
            command.Parameters.AddWithValue("@value8", new Guid(id));
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }

        public bool FNamevalidation(string Fname)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            var query = "select * from Employees";
            SqlCommand command = new SqlCommand(@query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            var EmployeeList =new List<Employee>();
            while (reader.Read())
            {
                var Employee = new Employee();
                Employee.EmpID = reader.GetString(0);
                Employee.FirstName = reader.GetString(1);
                Employee.MiddleName = reader.GetString(2);
                Employee.LastName = reader.GetString(3);    
                Employee.Phone = reader.GetString(4);
                Employee.Salary = reader.GetInt32(5);
                Employee.Age = reader.GetInt32(6);

               EmployeeList.Add(Employee);  
            }
            return EmployeeList;
        }

        public List<object> GetCountOfEmployeeByDepartment()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(string id)
        {
            throw new NotImplementedException();
        } 

        public List<Employee> GetTopSalariesEmployeesDepartment(int count)
        {
            throw new NotImplementedException();
        }

        /*public int InsertData()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string insrtQuery = "Insert into Student(Student_ID, Student_Name) values (@value1,@value2)";
            int ID = 2;
            string Name = "preksha";
            SqlCommand command = new SqlCommand(insrtQuery, connection);    
            command.Parameters.AddWithValue("@value1", ID);
            command.Parameters.AddWithValue("@value2", Name);
            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }*/

        public List<Employee> LastUpdatedEmployees()
        {
            throw new NotImplementedException();
        }

        public bool LNamevalidation(string Lname)
        {
            throw new NotImplementedException();
        }

        public void ObjectToString()
        {
            throw new NotImplementedException();
        }

        public bool Phonevalidation(string phone)
        {
            throw new NotImplementedException();
        }

        
    }

}
