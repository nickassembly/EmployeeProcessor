using EmployeeProcessor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Core.ViewModels
{
    public class NewEmployee
    {
        public Employee EmployeeInfo { get; set; }
        public Compensation EmployeePayInfo { get; set; }
        public EmployeeResponsibility EmployeeResponsibility { get; set; }
    }
}
