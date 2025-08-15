using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentMGT.Data;
using StudentMGT.Models;

namespace StudentMGT.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Course Course { get; set; }

        public IActionResult OnGet(int id)
        {
            Course = _context.Courses.Find(id);
            if (Course == null) return RedirectToPage("./Courses");
            return Page();
        }

        public IActionResult OnPost()
        {
            var course = _context.Courses.Find(Course.CourseID);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
            return RedirectToPage("./Courses");
        }
    }
}
