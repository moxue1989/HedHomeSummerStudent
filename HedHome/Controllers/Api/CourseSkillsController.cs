using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HedHome.Data;
using HedHome.Models.HedDataModel;

namespace HedHome.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/CourseSkills")]
    public class CourseSkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseSkills
        [HttpGet]
        public IEnumerable<Course> GetCourseSkill()
        {
            return _context.Courses
                .Include(c => c.CourseSkills)
                .ThenInclude(c => c.Skill);
        }

        // GET: api/CourseSkills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _context.Courses
                    .Include(c => c.CourseSkills)
                    .ThenInclude(c => c.Skill)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
       
        // POST: api/CourseSkills
        [HttpPost]
        public async Task<IActionResult> PostCourseSkill([FromBody] CourseSkill courseSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CourseSkill.Add(courseSkill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseSkillExists(courseSkill.CourseId, courseSkill.SkillId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourseSkill", new { id = courseSkill.CourseId }, courseSkill);
        }

        // DELETE: api/CourseSkills/5
        [HttpDelete]
        public async Task<IActionResult> DeleteCourseSkill([FromBody] CourseSkill courseSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCourseSkill = await _context.CourseSkill
                .SingleOrDefaultAsync(m => m.CourseId == courseSkill.CourseId &&
                m.SkillId == courseSkill.SkillId);
            if (existingCourseSkill == null)
            {
                return NotFound();
            }

            _context.CourseSkill.Remove(existingCourseSkill);
            await _context.SaveChangesAsync();

            return Ok(existingCourseSkill);
        }

        private bool CourseSkillExists(int courseId, int skillId)
        {
            return _context.CourseSkill.Any(e => e.CourseId == courseId && e.SkillId == skillId);
        }
    }
}