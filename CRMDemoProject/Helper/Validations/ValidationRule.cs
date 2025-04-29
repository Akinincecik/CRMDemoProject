using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMDemoProject
{
    public class ValidationRule
    {
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public bool Required { get; set; }
        public string RegexPattern { get; set; }
    }
}
