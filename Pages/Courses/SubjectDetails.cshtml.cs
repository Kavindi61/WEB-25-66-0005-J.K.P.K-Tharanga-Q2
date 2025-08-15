
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentMGT.Data;
using StudentMGT.Models;

namespace StudentMGT.Pages.Courses
{
    public class SubjectDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SubjectDetailsModel(ApplicationDbContext context) => _context = context;

        public Course Course { get; set; }
        public List<Student> Students { get; set; } = new();

        public string ErrorMessage { get; set; }

        public IActionResult OnGet(int id)
        {
            Course = _context.Courses.Find(id);
            if (Course == null)
            {
                ErrorMessage = "Course not found.";
                return Page();
            }

            Students = _context.Students
                .Where(s => s.CourseID == id)
                .ToList();

            return Page();
        }
    }
}


