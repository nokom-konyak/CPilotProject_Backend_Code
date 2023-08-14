using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Pilot_Project.Model
{
    [Index("mobileNo", IsUnique = true)]
    public class EmployeeMasterData
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeLocation { get; set; }
        [Required]
        public long mobileNo { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required, MaxLength(100)]
        public string ManagerName { get; set; }

        public ICollection<Course_Registration> Course_Registrations { get; set; }

    }
}
