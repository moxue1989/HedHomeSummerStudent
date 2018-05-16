using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HedHome.Data;
using HedHome.Models.HedDataModel;

namespace HedHome.Controllers
{
    public class CourseSkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoursesSkills
        public async Task<IActionResult> Index()
        {
            ViewData["active"] = "CourseSkills";
            ViewData["currentPage"] = 1;
            ViewData["perPage"] = 20;
            return View(await _context.Courses
                .Include(m => m.CourseSkills)
                .ThenInclude(m => m.Skill)
                .ToListAsync());
        }


        // GET: CoursesSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(m => m.CourseSkills)
                .ThenInclude(m => m.Skill)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // GET: CoursesSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .SingleOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(m => m.Id == id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
