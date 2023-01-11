using Businesslayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modellayer;
using System.Data;

namespace EmployeePayroll.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class EmployeeController : ControllerBase
        {
            private readonly IEmpRegBL empRegBL;
            public EmployeeController(IEmpRegBL empRegBL)
            {
                this.empRegBL = empRegBL;
            }
            [HttpPost("Add")]

            public IActionResult AddBook(EmployeeModel employeeModel)
            {
                try
                {
                    var res = empRegBL.AddEmployee(employeeModel);
                    if (res != null)
                    {
                        return Created("", new { success = true, message = "Employee Added sucessfully", data = res });
                    }
                    else
                    {
                        return BadRequest(new { success = false, message = "Faild to Add Employee" });
                    }
                }
                catch (System.Exception ex)
                {
                    return NotFound(new { success = false, message = ex.Message });
                }
            }
            [HttpGet("GetAllEmployee")]
            public IActionResult GetAllBook()
            {
                try
                {
                    var res = empRegBL.GetAllEmployees();
                    if (res != null)
                    {
                        return Created("", new { data = res });
                    }
                    else
                    {
                        return BadRequest(new { success = false, message = "Faild to getall Employee" });
                    }
                }
                catch (System.Exception ex)
                {
                    return NotFound(new { success = false, message = ex.Message });
                }
            }

        [HttpGet("GetEmployeeById")]
        public IActionResult GetBookbyId(int EmpId)
        {
            try
            {
                var res = empRegBL.GetEmployeeData(EmpId);
                if (res != null)
                {
                    return Created("", new { data = res });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Faild to get Employee" });
                }
            }
            catch (System.Exception ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteBookbyId(int EmpId)
        {
            try
            {
                var res = empRegBL.DeleteEmployee(EmpId);
                if (res != null)
                {
                    return Created("", new { success = true, message = "Employee Deleted sucessfully" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Faild to delete Employee" });
                }
            }
            catch (System.Exception ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpPut("UpdateEmployeeDetail")]
        public IActionResult UpdateBook(EmployeeModel employeeModel)
        {
            try
            {
                var res = empRegBL.UpdateEmployee(employeeModel);
                if (res != null)
                {
                    return Created("", new { success = true, message = "Employee detail updated sucessfully", data = res });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Faild to update Details" });
                }
            }
            catch (System.Exception ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }


    }
}
