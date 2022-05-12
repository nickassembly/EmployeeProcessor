using EmployeeProcessor.Core.ViewModels;
using EmployeeProcessor.Data;
using EmployeeProcessor.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProcessor.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase, IEmployeeRepository
    {
        private readonly EmployeeProcessorDbContext _context;
        public EmployeeController(EmployeeProcessorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeesToReturn = new();

            try
            {
                var employees = _context.Employees.ToList();
                // TODO: join with compensations table and responsibilities table to improve performance

                foreach (var employee in employees)
                {
                    var employeeCompensation = _context.Compensations.Where(x => x.Employees.Contains(employee)).FirstOrDefault();

                    var employeeJob = _context.EmployeeResponsibilities.Where(x => x.Employees.Contains(employee)).FirstOrDefault();

                    Employee newEmployee = new Employee
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Address = employee.Address,
                        Compensation = employeeCompensation,
                        EmployeeResponsibility = employeeJob
                    };

                    employeesToReturn.Add(employee);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return employeesToReturn;
        }

        [HttpPost]
        public ActionResult AddNewEmployee([FromBody] Employee newEmployee)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            //todo create Repository pattern and just await repo.AddEmployee(employee) interface method...

            // or...
            Employee employeeToAdd = new Employee
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                Address = newEmployee.Address
            };

            // TODO: Check Employee Position to determine if Supervisor, set pay salary
            // If Manager, set max expense amount

            Compensation payObj = new();
            EmployeeResponsibility responsibilities = new();

            _context.Employees.Add(employeeToAdd);
            _context.EmployeeResponsibilities.Add(responsibilities);
            _context.Compensations.Add(payObj);
            _context.SaveChanges();

             return Ok(employeeToAdd);

        }

      
    }
    // Employee Repo
    public interface IEmployeeRepository
    {
        ActionResult AddNewEmployee(Employee employee);
    }
}