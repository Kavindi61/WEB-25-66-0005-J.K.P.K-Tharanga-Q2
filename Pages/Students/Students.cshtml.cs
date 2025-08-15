
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentMGT.Data;
using StudentMGT.Models;

namespace StudentMGT.Pages.Students
{
    public class StudentsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public StudentsModel(ApplicationDbContext context) => _context = context;

        public List<Student> Students { get; set; }
        public string SearchString { get; set; }

        public void OnGet(string searchString)
        {
            SearchString = searchString;
            var query = _context.Students.Include(s => s.Course).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(s => s.Name.Contains(searchString) || s.City.Contains(searchString) || s.Course.Name.Contains(searchString));

            Students = query.ToList();
        }
    }
}

