using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Data.Models
{
    public class EmployeeCompensation
    {
        [Key]
        public int Id { get; set; }

        public int CompensationId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Compensation Compensation { get; set; }
    }
}
