using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class EmployeePayCategory
    {
        public EmployeePayCategory()
        {
            Employee = new HashSet<Employee>();
        }

        public string Code { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
