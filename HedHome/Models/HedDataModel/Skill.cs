using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HedHome.Models.HedDataModel
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<CourseSkill> CourseSkills { get; set; }
    }

    public class CourseSkill
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
