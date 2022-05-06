using EmployeeProcessor.Data.Enums;

namespace EmployeeProcessor.Data.Models
{
    public class EmployeeResponsibility
    {
        // 1 to 1 relationship with Employee 

        public int Id { get; set; }
        public CurrentRank EmployeeRank { get; set; }
        public EmployeePayType PayType { get; set; }
        public decimal? MaxExpenseAccount { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }

    
}
