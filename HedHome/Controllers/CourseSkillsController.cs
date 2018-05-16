using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HedHome.Data;
using HedHome.Models.HedDataModel;
using PagedList;

namespace HedHome.Controllers
{
    public class CourseSkillsController : Controller
    {
        private static int? _totalCount;
        private readonly ApplicationDbContext _context;

        public CourseSkillsController(ApplicationDbContext context)
        {
            _context = context;
            if (_totalCount == null)
            {
                _totalCount = _context.Courses
                .Count();
            }

        }

        // GET: CoursesSkills
        public IActionResult Index(int? page)
        {
            ViewData["active"] = "CourseSkills";
            ViewData["totalCount"] = _totalCount;
            ViewData["currentPage"] = page.HasValue ? page : 1;
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Course> courses = _context.Courses
                .Include(m => m.CourseSkills)
                .ThenInclude(m => m.Skill)
                .ToPagedList(pageIndex, pageSize);
            return View(courses);
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
