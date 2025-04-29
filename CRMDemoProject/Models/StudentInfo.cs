using System.Collections.Generic;

namespace CRMDemoProject.Models
{
    public class StudentInfo
    {
        public StudentInfo()
        {
            ContactInformation = new List<ContactInfo>();
        }

        public List<ContactInfo> ContactInformation { get; set; }

        public PersonInfo PersonInfo { get; set; }
    }
}
