using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pilot_Project.Model
{
    [PrimaryKey(nameof(EmployeeId), nameof(CourseId))]
    public class Course_Registration
    {
        [ForeignKey("EmployeeMasterData")]
        [Column(Order = 1)]
        public int EmployeeId { get; set; }
        public virtual EmployeeMasterData? EmployeeMasterData { get; set; }  // lazy loading

        [Column(Order = 2)]
        public int CourseId { get; set; }
    }
}
