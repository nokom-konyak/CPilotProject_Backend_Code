using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pilot_Project.Model;

namespace Pilot_Project.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/Pilot_Project")]
    [ApiController]
    public class PilotProjectController : ControllerBase
    {
        public readonly PilotProjectDBContext context;
        public PilotProjectController(PilotProjectDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/api/Pilot_Project/GetAllCourse")]
        public List<Course> Get()
        {
            var courses = context.Course.ToList();
            return courses;
        }

        [HttpGet]
        [Route("/api/Pilot_project/GetCourseById")]
        public Course Get(int Id)
        {
            var c = new Course();
            try
            {
                c = context.Course.Where(x => x.CourseId == Id).FirstOrDefault();
                return c;
            }
            catch
            {
                return c;
            }
        }

        [HttpGet]
        [Route("/api/Pilot_Project/GetEmployeeByEmailId")]
        public EmployeeMasterData Get(string email)
        {
            var e = new EmployeeMasterData();
            try
            {
                e = context.EmployeeMasterData.Where(x => x.EmailId == email).FirstOrDefault();
                return e;
            }
            catch
            {
                return e;
            }
        }

        [HttpPost]
        [Route("/api/Pilot_Project/InsertCourse")]
        public bool Post([FromBody] Course c)
        {
            try
            {
                context.Course.Add(c);
                var res = context.SaveChanges();
                if (res != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        [Route("/api/Pilot_Project/NewRegistration")]
        public bool Post([FromBody] Course_Registration o)
        {
            try
            {
                context.Course_Registration.Add(o);
                var res = context.SaveChanges();
                if (res != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                //throw new Exception("Duplicate Registration");
                return false;
            }

        }
    }
}
