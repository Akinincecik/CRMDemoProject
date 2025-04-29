using System;

namespace CRMDemoProject.Models
{
    public class PersonInfo
    {
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MainLanguage { get; set; }
        public string ForeignLanguage { get; set; }
        public string Gender { get; set; }
        public string PicturePath { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
    }
}
