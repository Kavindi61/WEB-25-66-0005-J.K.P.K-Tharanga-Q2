using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentMGT.Data;
using StudentMGT.Models;

namespace StudentMGT.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context) => _context = context;

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
            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Course).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToPage("./Courses");
        }
    }
}
