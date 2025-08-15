

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentMGT.Data;
using StudentMGT.Models;

namespace StudentMGT.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Student Student { get; set; }
        public List<SelectListItem> Courses { get; set; }

        public IActionResult OnGet(int id)
        {
            Student = _context.Students.Find(id);
            if (Student == null) return RedirectToPage("./Students");

            Courses = _context.Courses
                .Select(c => new SelectListItem { Value = c.CourseID.ToString(), Text = c.Name })
                .ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Courses = _context.Courses
                    .Select(c => new SelectListItem { Value = c.CourseID.ToString(), Text = c.Name })
                    .ToList();
                return Page();
            }

            _context.Attach(Student).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToPage("./Students");
        }
    }
}

