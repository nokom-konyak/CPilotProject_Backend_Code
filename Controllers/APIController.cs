using OfficeOpenXml;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Pilot_Project.Model;

namespace Pilot_Project.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/Pilot_Project_Excel")]
    [ApiController]
    public class APIController :ControllerBase
    {

        [HttpGet]
        [Route("/api/Pilot_Project_Excel/GetAllCourse")]
        public ActionResult<IEnumerable<Course_Excel>> Get()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Model", "Course_Details.xlsx");
            var courseDetails = new List<Course_Excel>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet
                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    double excelDateValue = worksheet.Cells[row,4].GetValue<double>();
                    DateTime dateTimeValue = DateTime.FromOADate(excelDateValue);
                    string result = dateTimeValue.ToString("dd-MMM-yyyy");

                    double excelDateValue1 = worksheet.Cells[row, 5].GetValue<double>();
                    DateTime dateTimeValue1 = DateTime.FromOADate(excelDateValue1);
                    string result1 = dateTimeValue1.ToString("dd-MMM-yyyy");

                    var course = new Course_Excel
                    {
                        CourseId = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                        CourseName = worksheet.Cells[row, 2].Value?.ToString(),
                        CourseType = worksheet.Cells[row, 3].Value?.ToString(),
                        startDate =result,
                        endDate = result1,
                        Time = worksheet.Cells[row, 6].Value?.ToString(),
                        durationPerDay = worksheet.Cells[row, 7].Value?.ToString(),
                        Total_days= worksheet.Cells[row, 8].Value?.ToString(),
                        Total_duration= worksheet.Cells[row, 9].Value?.ToString(),
                        CourseDesc= worksheet.Cells[row, 10].Value?.ToString(),
                        Topics= worksheet.Cells[row, 11].Value?.ToString(),
                        TargetAudience= worksheet.Cells[row, 12].Value?.ToString(),
                        SoftwareRequirements= worksheet.Cells[row, 13].Value?.ToString(),
                        Prerequites= worksheet.Cells[row, 14].Value?.ToString(),
                        Category= worksheet.Cells[row, 16].Value?.ToString(),
                        //EnrollmentLink= worksheet.Cells[row, 17].Hyperlink?.ToString(),
                    };
                    if(course.CourseId==0)
                    {
                        break;
                    }
                    courseDetails.Add(course);
                }
            }
            return Ok(courseDetails);
        }
    }
}
