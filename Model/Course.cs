using System.ComponentModel.DataAnnotations;
namespace Pilot_Project.Model
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseImage { get; set; }
        [Required]
        public string CourseDesc { get; set; }
        [Required]
        public DateTime startTime { get; set; }
        [Required]
        public DateTime endTime { get; set; }


    }
}
