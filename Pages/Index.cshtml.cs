using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentMGT.Data;
using StudentMGT.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentMGT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard data
        public int TotalCourses { get; set; }
        public int TotalStudents { get; set; }
        public List<CourseStats> CourseDetails { get; set; } = new();

        public void OnGet()
        {
            // Total counts
            TotalCourses = _context.Courses.Count();
            TotalStudents = _context.Students.Count();

            // Course details with CourseID
            CourseDetails = _context.Courses
                .Include(c => c.Students)
                .Select(c => new CourseStats
                {
                    CourseID = c.CourseID,
                    CourseName = c.Name,
                    LecturerName = c.LecturerName,
                    StudentCount = c.Students.Count()
                })
                .ToList();
        }
    }

    public class CourseStats
    {
        public int CourseID { get; set; } 
        public string CourseName { get; set; } = string.Empty;
        public string LecturerName { get; set; } = string.Empty;
        public int StudentCount { get; set; }
    }
}

