using Microsoft.Data.SqlClient;
using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StoredProcedure : IEmployeeService

    {
        private readonly string _connectionString = @"Data Source = 192.168.10.28\SQLEX2017;Initial Catalog=Preksha; User Id=sysfore.ea;Password=Sys@2024#;Encrypt=false";

        public List<Employee> GetAllEmployees()
        {
            List<Employee> emp = new List<Employee>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var Qruey = "gtalep";
            using SqlCommand command = new SqlCommand(Qruey, connection);

            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                Employee employ = new Employee();
                employ.EmpID =  reader.GetString(0);
                employ.FirstName = reader.GetString(1);
                employ.MiddleName = reader.GetString(2);
                employ.LastName = reader.GetString(3);
                employ.Phone = reader.GetString(4);
                employ.Age = reader.GetInt32(5);
                employ.Salary = reader.GetInt32(6);
                employ.Department = (Dept)reader.GetInt32(7);

                emp.Add(employ);


            }
            return emp;
        }

        public int AddEmployee(EmployeeDto employee)
        {
            Employee emp = new Employee(employee);
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var Qruey = "AddEmp";
            using SqlCommand command = new SqlCommand(Qruey, connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@value1", SqlDbType.UniqueIdentifier).Value = emp.EmpID;
            command.Parameters.Add("@value2", SqlDbType.VarChar).Value = emp.FirstName;
            command.Parameters.Add("@value3", SqlDbType.VarChar).Value = emp.MiddleName;
            command.Parameters.Add("@value4", SqlDbType.VarChar).Value = emp.LastName;
            command.Parameters.Add("@value5", SqlDbType.VarChar).Value = emp.Phone;
            command.Parameters.Add("@value6", SqlDbType.Int).Value = emp.Age;
            command.Parameters.Add("@value7", SqlDbType.Int).Value = emp.Salary;
            command.Parameters.Add("@value8", SqlDbType.Int).Value = (Dept)emp.Department;
            int rowAffected = command.ExecuteNonQuery();

            return rowAffected;
        }
        public int UpdateEmployee(string id, EmployeeDto employee)
        {
            var Qruey = "UpdateEmployee";
            Employee emp = new Employee(employee);
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(Qruey, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@value1", SqlDbType.UniqueIdentifier).Value = id;
            command.Parameters.Add("@value2", SqlDbType.VarChar).Value = employee.FirstName;
            command.Parameters.Add("@value3", SqlDbType.VarChar).Value = employee.MiddleName;
            command.Parameters.Add("@value4", SqlDbType.VarChar).Value = employee.LastName;
            command.Parameters.Add("@value5", SqlDbType.VarChar).Value = employee.phone;
            command.Parameters.Add("@value6", SqlDbType.Int).Value = employee.salary;
            command.Parameters.Add("@value7", SqlDbType.Int).Value = employee.age;
            command.Parameters.Add("@value8", SqlDbType.Int).Value = (Dept)employee.Department;
            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }

        public int DeleteEmployee(string EmpId)
        {
            var Query = "DeleteEmp";
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@value", SqlDbType.UniqueIdentifier).Value = EmpId;
            int rowsAffected = command.ExecuteNonQuery();

            return (int)rowsAffected;
        }

        public bool FNamevalidation(string Fname)
        {
            throw new NotImplementedException();
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
