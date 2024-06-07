using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmployeeDto
    {

        //public Name name { get; set; }
       public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public int age { get; set; }
       
        public string phone { get; set; }

        public int salary { get; set; }

        public Dept Department { get; set; }
    }
    /*public class Name
    {
        //[RegularExpression("^[a-zA-Z]+$")]
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
    }
*/
}
