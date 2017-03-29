using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRMSys.UI
{
    public class SalarySheetItemRpt
    {
        public decimal Bonus { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Fine { get; set; }
        public decimal Other { get; set; }
        public string EmployeeName { get; set; }
    }
}
