using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        DateTime current = DateTime.Now;

        public Employee()
        {
            
        }
        public Employee(EmployeeDto emp)
        {
            this.Age = emp.age;
            this.FirstName = emp.FirstName;
            this.MiddleName = emp.MiddleName;
            this.LastName = emp.LastName;
            this.Phone= emp.phone; ;
            this.Salary = emp.salary;
            this.Department = emp.Department;
            EmpID = Guid.NewGuid().ToString();
            IsActive = true;
            CreatedOn =current.ToShortDateString();
            
           // UpdatedOn = DateTime.Now;
        }
        public string EmpID { get; set; }
        public  string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
       
        public string Phone { get; set; }
        public int Salary { get; set; }
        public string CreatedOn { get; set; } 
       // public DateTime? UpdatedOn { get; set; } = null;
        
        public bool? IsActive { get; set; }
        public Dept Department { get; set; }
    }


}


