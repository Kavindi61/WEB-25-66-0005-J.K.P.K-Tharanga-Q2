
namespace StudentMGT.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string LecturerName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
