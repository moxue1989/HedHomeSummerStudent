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

        // GET: CourseSkills
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseSkill.Include(c => c.Course).Include(c => c.Skill);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseSkill = await _context.CourseSkill
                .Include(c => c.Course)
                .Include(c => c.Skill)
                .SingleOrDefaultAsync(m => m.CourseId == id);
            if (courseSkill == null)
            {
                return NotFound();
            }

            return View(courseSkill);
        }

        // GET: CourseSkills/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title");
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Name");
            return View();
        }

        // POST: CourseSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,SkillId")] CourseSkill courseSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title", courseSkill.CourseId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Name", courseSkill.SkillId);
            return View(courseSkill);
        }

        // GET: CourseSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseSkill = await _context.CourseSkill.SingleOrDefaultAsync(m => m.CourseId == id);
            if (courseSkill == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title", courseSkill.CourseId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Name", courseSkill.SkillId);
            return View(courseSkill);
        }

        // POST: CourseSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,SkillId")] CourseSkill courseSkill)
        {
            if (id != courseSkill.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseSkillExists(courseSkill.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Title", courseSkill.CourseId);
            ViewData["SkillId"] = new SelectList(_context.Skills, "Id", "Name", courseSkill.SkillId);
            return View(courseSkill);
        }

        // GET: CourseSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseSkill = await _context.CourseSkill
                .Include(c => c.Course)
                .Include(c => c.Skill)
                .SingleOrDefaultAsync(m => m.CourseId == id);
            if (courseSkill == null)
            {
                return NotFound();
            }

            return View(courseSkill);
        }

        // POST: CourseSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseSkill = await _context.CourseSkill.SingleOrDefaultAsync(m => m.CourseId == id);
            _context.CourseSkill.Remove(courseSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseSkillExists(int id)
        {
            return _context.CourseSkill.Any(e => e.CourseId == id);
        }
    }
}
