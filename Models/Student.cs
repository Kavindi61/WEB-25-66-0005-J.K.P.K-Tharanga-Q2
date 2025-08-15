
namespace StudentMGT.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}