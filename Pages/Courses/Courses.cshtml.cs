using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentMGT.Data;
using StudentMGT.Models;

namespace StudentMGT.Pages.Courses
{
    public class CoursesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CoursesModel(ApplicationDbContext context) => _context = context;

        public List<Course> Courses { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            var query = _context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(c => c.Name.Contains(SearchTerm) || c.LecturerName.Contains(SearchTerm));
            }

            Courses = query.ToList();
        }
    }
}
