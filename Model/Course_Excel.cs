using System;
using System.ComponentModel.DataAnnotations;



namespace Pilot_Project.Model
{
    public class Course_Excel
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseType { get; set; }
        [Required]
        public string startDate { get; set; }
        [Required]
        public string endDate { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string durationPerDay { get; set; }
        [Required]
        public string Total_days { get; set; }
        [Required]
        public string Total_duration { get; set; }
        [Required]
        public string CourseDesc { get; set; }
        [Required]
        public string Topics { get; set; }
        [Required]
        public string TargetAudience { get; set; }
        [Required]
        public string SoftwareRequirements { get; set; }
        [Required]
        public string Prerequites { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string EnrollmentLink { get; set; }

    }
}