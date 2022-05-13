using EmployeeProcessor.Core.ViewModels;
using EmployeeProcessor.Data;
using EmployeeProcessor.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProcessor.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeProcessorDbContext _context;
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeController(EmployeeProcessorDbContext context, IEmployeeRepository employeeRepo)
        {
            _context = context;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            // TODO: Abstract using EmployeeRepo instead

            _employeeRepo.GetAllEmployees();
            List<Employee> employeesToReturn = new();

            try
            {
                var employees = _context.Employees.ToList();

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
        List<Employee> GetAllEmployees();
        ActionResult AddNewEmployee(Employee employee);
    }
}