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

                foreach (var employee in employees)
                {
                    Employee newEmployee = new Employee
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Address = employee.Address
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
        public async Task<IActionResult> AddNewEmployee(NewEmployee newEmployee)
        {
            Employee employeeToAdd = new Employee
            {
                FirstName = newEmployee.EmployeeInfo.FirstName,
                LastName = newEmployee.EmployeeInfo.LastName,
                Address = newEmployee.EmployeeInfo.Address
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
}