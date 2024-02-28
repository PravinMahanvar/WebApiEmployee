using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApiEmployee.Model;
using WebApiEmployee.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEmployee.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeeController : ControllerBase
    {
        private readonly IEmployeeService service;
        public EmployeeeController(IEmployeeService service)
        {
            this.service = service;
        }
        // GET: api/<EmployeeeController>
        [HttpGet]
        [Route("GetEmployeees")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetEmployees();
                return new ObjectResult(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // GET api/<EmployeeeController>/5
        [HttpGet]
        [Route("GetEmployeeeById/{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetEmployeeById(id);
                if (model != null)
                    return new ObjectResult(model);
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<EmployeeeController>
        [HttpPost]
        [Route("AddEmployeee")]
        public IActionResult Post([FromBody] Employee employeee)
        {
            try
            {
                int result = service.AddEmployee(employeee);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<EmployeeeController>/5
        [HttpPut]
        [Route("UpdateEmployeee")]
        public IActionResult Put(int id, [FromBody] Employee employeee)
        {
            try
            {
                int result = service.UpdateEmployee(employeee);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/<EmployeeeController>/5
        [HttpDelete]
        [Route("DeleteEmployeee/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = service.DeleteEmployee(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
