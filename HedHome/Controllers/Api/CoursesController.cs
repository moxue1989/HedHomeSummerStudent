using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HedHome.Data;
using HedHome.Models.HedDataModel;
using HedHome.Models.HedViewModels;

namespace HedHome.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses
                .Include(c => c.DeliveryType)
                .ToList();
        }

        [HttpGet]
        [Route("/api/Courses/Import")]
        public CourseImportV1 GetCoursesImport()
        {
            return new CourseImportV1()
            {
                Title = "title of course",
                CourseNumber = "course Number",
                Description = "desc",
                Offering = "Delivery type name"
            };
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _context.Courses.SingleOrDefaultAsync(m => m.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] CourseImportV1 courseImport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string deliveryType = courseImport.Offering;
            bool isexisting = _context.DeliveryTypes.Any(d => d.Name == deliveryType);
            DeliveryType existingDelivery;

            if (isexisting)
            {
                existingDelivery = _context.DeliveryTypes.First(d => d.Name == deliveryType);
            }
            else
            {
                existingDelivery = new DeliveryType()
                {
                    Name = deliveryType
                };
                _context.DeliveryTypes.Add(existingDelivery);
                await _context.SaveChangesAsync();
            }
            
            Course newCourse = new Course()
            {
                Title = courseImport.Title,
                CourseNumber = courseImport.CourseNumber,
                Description = courseImport.Description,
                Campus = _context.Campuses.First(),
                City = _context.Cities.First(),
                DeliveryType = existingDelivery
            };

            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = newCourse.Id }, newCourse);
        }
    }
}