using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SALARY_CALCULATOR
{
    public class OutputModel
    {
        public string Name { get; set; }
        public string RatePerHour { get; set; }
        public string GrossPay { get; set; }
        public string Deductions { get; set; }
        public string NetPay { get; set; }
    }
}
