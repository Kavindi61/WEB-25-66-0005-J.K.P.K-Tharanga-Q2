using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentMGT.Data;
using StudentMGT.Models;

namespace StudentMGT.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Student Student { get; set; }

        public IActionResult OnGet(int id)
        {
            Student = _context.Students.Find(id);
            if (Student == null) return RedirectToPage("./Students");
            return Page();
        }

        public IActionResult OnPost()
        {
            var student = _context.Students.Find(Student.StudentID);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToPage("./Students");
        }
    }
}
