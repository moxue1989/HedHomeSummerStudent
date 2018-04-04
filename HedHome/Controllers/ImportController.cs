using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using HedHome.Data;
using HedHome.Models.HedDataModel;
using HedHome.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HedHome.Controllers
{
    [Authorize]
    public class ImportController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ImportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["message"] = TempData["message"];
            var importTypes = new SelectList(Enum.GetValues(typeof(ImportType)).Cast<ImportType>()
                .Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList(), "Value", "Text");
            return View(importTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Import(int importType, IFormFile postedFile)
        {
            if (postedFile == null)
            {
                TempData["message"] = "no file uploaded";
                return RedirectToAction("Index");
            }

            switch ((ImportType)importType)
            {
                case ImportType.Skill:
                    return await ImportSkills(postedFile);
                case ImportType.SubjectType:
                    return await ImportSubjects(postedFile);
                case ImportType.City:
                    return await ImportCities(postedFile);
                case ImportType.DurationType:
                    return await ImportDurationTypes(postedFile);
                case ImportType.StudyType:
                    return await ImportStudyTypes(postedFile);
                case ImportType.DeliveryType:
                    return await ImportDeliveryTypes(postedFile);
                case ImportType.Institution:
                    return await ImportInstitutions(postedFile);
                case ImportType.Faculty:
                    return await ImportFaculties(postedFile);
                default:
                    return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> ImportSkills(IFormFile postedFile)
        {
            CsvImporter<Skill> importer = new CsvImporter<Skill>();
            int inserted = await ImportRecords(postedFile, importer);
            TempData["message"] = inserted + " skills were inserted";
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> ImportSubjects(IFormFile postedFile)
        {
            CsvImporter<SubjectType> importer = new CsvImporter<SubjectType>();
            int inserted = await ImportRecords(postedFile, importer);
            TempData["message"] = inserted + " subjects were inserted";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ImportCities(IFormFile postedFile)
        {
            CsvImporter<Skill> importer = new CsvImporter<Skill>();
            int inserted = await ImportRecords(postedFile, importer);
            TempData["message"] = inserted + " cities were inserted";
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> ImportDurationTypes(IFormFile postedFile)
        {
            CsvImporter<SubjectType> importer = new CsvImporter<SubjectType>();
            int inserted = await ImportRecords(postedFile, importer);
            TempData["message"] = inserted + " duration types were inserted";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ImportStudyTypes(IFormFile postedFile)
        {
            CsvImporter<Skill> importer = new CsvImporter<Skill>();
            int inserted = await ImportRecords(postedFile, importer);
            TempData["message"] = inserted + " study types were inserted";
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> ImportDeliveryTypes(IFormFile postedFile)
        {
            CsvImporter<SubjectType> importer = new CsvImporter<SubjectType>();
            int inserted = await ImportRecords(postedFile, importer);
            TempData["message"] = inserted + " delivery types were inserted";
            return RedirectToAction("Index");
        }
        private async Task<IActionResult> ImportFaculties(IFormFile postedFile)
        {
            CsvImporter<Faculty> importer = new CsvImporter<Faculty>();
            int inserted = await ImportRecords(postedFile, importer);
            TempData["message"] = inserted + " institutions were inserted";
            return RedirectToAction("Index");
        }
        private async Task<IActionResult> ImportInstitutions(IFormFile postedFile)
        {
            CsvImporter<Institution> importer = new CsvImporter<Institution>();
            int inserted = await ImportRecords(postedFile, importer);
            TempData["message"] = inserted + " skills were inserted";
            return RedirectToAction("Index");
        }

        private async Task<int> ImportRecords<T>(IFormFile postedFile, CsvImporter<T> importer) where T : class
        {
            using (var reader = new StreamReader(postedFile.OpenReadStream()))
            {
                IEnumerable<T> records = importer.Import(reader);
                foreach (T record in records)
                {
                    _context.Add(record);
                }
            }
            int inserted = await _context.SaveChangesAsync();
            return inserted;
        }
    }
}