using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HedHome.Data;
using HedHome.Models.HedDataModel;

namespace HedHome.Cache
{
    public class SkillCache
    {
        private ConcurrentBag<Skill> _skillBag;
        private readonly ApplicationDbContext _dbContext;

        public SkillCache(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Skill> GetAllSkills()
        {
            if (_skillBag == null)
            {
                _skillBag = new ConcurrentBag<Skill>(_dbContext.Skills.ToList());
            }
            return _skillBag.ToList();
        }

        public void ReloadSKills()
        {
            _skillBag = new ConcurrentBag<Skill>(_dbContext.Skills.ToList());
        }
    }
}
