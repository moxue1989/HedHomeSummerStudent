using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HedHome.Models.HedDataModel
{
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<InstitutionFaculty> InstitutionFaculties { get; set; }
    }
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<InstitutionFaculty> InstitutionFaculties { get; set; }
    }
    public class Campus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class InstitutionFaculty
    {
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
