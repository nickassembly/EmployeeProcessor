using System.ComponentModel.DataAnnotations;

namespace EmployeeProcessor.Data.Models
{
    public class Employee
    {
        // 1 to 1 relationship with EmployeePay

        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public EmployeeCompensation EmployeeCompensation { get; set; }
        public virtual EmployeeResponsibility EmployeeResponsibility { get; set; }
    }
}
