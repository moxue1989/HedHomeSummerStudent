using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HedHome.Cache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HedHome.Data;
using HedHome.Models.HedDataModel;
using HedHome.Models.HedViewModels;

namespace HedHome.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Skills")]
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SkillCache _skillCache;

        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
            _skillCache = new SkillCache(_context);
        }
        
        // GET: api/Skills
        [HttpGet]
        public IEnumerable<Skill> SearchSkills(string search)
        {
            return SearchSkillsByName(search);
        }

        // GET: api/Skills/Search
        [HttpGet]
        [Route("/api/Skills/Search")]
        public IEnumerable<SkillView> SearchSkillsJquery(string term)
        {
            return SearchSkillsByName(term).Select(s => new SkillView
            {
                    label = s.Name,
                    value = s.Id
                });
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public IActionResult GetSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skill = _skillCache.GetAllSkills().Find(s => s.Id == id);

            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }
        private IEnumerable<Skill> SearchSkillsByName(string search)
        {
            return _skillCache.GetAllSkills()
                .Where(s => s.Name.ToLower().Contains(search.ToLower()))
                .OrderByDescending(s => s.CourseSkills.Count)
                .ThenBy(s => Regex.Match(s.Name.ToLower(), search).Index)
                .ThenBy(s => s.Name.ToLower())
                .Take(10);
        }
    }
}