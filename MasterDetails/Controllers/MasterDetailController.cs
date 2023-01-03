using MasterDetails.Data;
using MasterDetails.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasterDetails.Controllers
{
    public class MasterDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MasterDetailController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Applicants.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
            return View(applicant);
        }

        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            _context.Add(applicant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var item = _context.Applicants.Include(e => e.Experiences).Where(m => m.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _context.Applicants.Include(e => e.Experiences).Where(m => m.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(Applicant applicant)
        {
            _context.Applicants.Remove(applicant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _context.Applicants.Include(e => e.Experiences).Where(m => m.Id == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Applicant applicant)
        {
            applicant.Experiences.RemoveAll(n=> n.YearsWorked == 0);
            _context.Attach(applicant);
            _context.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}
