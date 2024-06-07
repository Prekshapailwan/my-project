using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Services;
using Services.Interface;

namespace EmpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService = new EmployeeService();
        // IEmployeeService db = new DatabaseManager();
        IEmployeeService db = new StoredProcedure();



        [Route("/GetAllEmployees")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
           // var employees = _employeeService.GetAllEmployees();
          var data = db.GetAllEmployees();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(string id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpGet]

        [Route("GetDepartmentById")]
        public IActionResult GetDepartmentById(int id)
        {
            return Ok(_employeeService.GetDepartmentById(id));

        }
        [HttpGet]
        [Route("count")]

        public IActionResult GetCountOfEmployeeByDepartment()
        {
            var count = _employeeService.GetCountOfEmployeeByDepartment();
            return Ok(count);
        }

        [HttpPost]
        [Route("/AddEmployee")]
        public IActionResult AddEmployee(EmployeeDto employee)
        {
            if (!_employeeService.FNamevalidation(employee.FirstName))
            {
                return BadRequest("enter only alphabets");
            }

            if (!_employeeService.LNamevalidation(employee.LastName))
            {
                return BadRequest("enter only alphabets");
            }
            if (!_employeeService.Phonevalidation(employee.phone))
            {
                return BadRequest("number should be 10 digits");
            }
            _employeeService.AddEmployee(employee);
            db.AddEmployee(employee);
            return Ok("employee created");
        }



        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(string id, EmployeeDto employee)
        {
            try
            {
                db.UpdateEmployee(id, employee);
                _employeeService.UpdateEmployee(id, employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest("somthing went weong");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(string id)
        {
            try
            {
                /*db.DeleteEmployee(id)*/;
                //_employeeService.DeleteEmployee(id); 
                return Ok(db.DeleteEmployee(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("lastupdated")]
        public IActionResult LastUpdatedEmployees()
        {
            var LastUpdate = _employeeService.LastUpdatedEmployees();

            return Ok(LastUpdate);
        }
        [HttpGet]
        [Route("TopSalary")]

        public IActionResult GetTopSalariesEmployeesDepartment(int count)
        {
            var TopSalary = _employeeService.GetTopSalariesEmployeesDepartment(count);
            return Ok(TopSalary);
        }
    }
}
        
        /*public ActionResult GetEmployee()
        {
            db.InsertData();
            return Ok(db);
        }
*/

    

