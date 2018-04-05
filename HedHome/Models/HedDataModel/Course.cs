using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HedHome.Models.HedDataModel
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CourseNumber { get; set; }
        public string Description { get; set; }
        public int DurationValue { get; set; }
        public Decimal StudentPrice { get; set; }
        public bool CompetencyBased { get; set; }
        public bool PracticumRequired { get; set; }
        public int Duration { get; set; }
        public DurationType DurationType { get; set; }
        public StudyType StudyType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public SubjectType SubjectType { get; set; }
        public Institution Institution { get; set; }
        public Faculty Faculty { get; set; }
        public Campus Campus { get; set; }
        public City City { get; set; }
        [JsonIgnore]
        public ICollection<Prerequisite> PrerequisitesOf { get; set; }
        [JsonIgnore]
        public ICollection<Prerequisite> PrerequisitesFor { get; set; }
        [JsonIgnore]
        public ICollection<CourseSkill> CourseSkills { get; set; }
    }

    public class Prerequisite
    {
        public int ParentId { get; set; }
        public Course ParentCourse { get; set; }
        public int ChildId { get; set; }
        public Course ChildCourse { get; set; }
    }

    public class SubjectType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DurationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class StudyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DeliveryType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
