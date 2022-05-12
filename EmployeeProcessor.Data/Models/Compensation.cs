using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Data.Models
{
    public class Compensation 
    {
        [Key]
        public int Id { get; set; }
        public EmployeePayType PayType { get; set; }
        public decimal? AnnualSalaryAmount { get; set; }
        public decimal? PayPerHourAmount { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
