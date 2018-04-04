using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HedHome.Models.HedDataModel
{
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<InstitutionFaculty> InstitutionFaculties { get; set; }
        public ICollection<Campus> Campuses { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<InstitutionFaculty> InstitutionFaculties { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
    public class Campus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public Institution Institution { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

    public class InstitutionFaculty
    {
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        
    }
}
