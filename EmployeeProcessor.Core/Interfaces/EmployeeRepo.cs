using EmployeeProcessor.Core.Controllers;
using EmployeeProcessor.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Core.Interfaces
{
    public class EmployeeRepo : IEmployeeRepository
    {
        public ActionResult AddNewEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
