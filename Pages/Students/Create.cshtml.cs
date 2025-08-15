
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMGT.Data;
using StudentMGT.Models;

namespace StudentMGT.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Student Student { get; set; }

        public List<SelectListItem> Courses { get; set; }

        public void OnGet()
        {
            Courses = _context.Courses
                .Select(c => new SelectListItem { Value = c.CourseID.ToString(), Text = c.Name })
                .ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                OnGet();
                return Page();
            }

            _context.Students.Add(Student);
            _context.SaveChanges();
            return RedirectToPage("./Students");
        }
    }
}
