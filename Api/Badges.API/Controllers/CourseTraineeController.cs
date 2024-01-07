using Badges.Core.Data;
using Badges.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badges.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTraineeController : ControllerBase
    {

        private readonly ICourseTraineeService _courseTraineeService;

        public CourseTraineeController(ICourseTraineeService courseTraineeService)
        {
            _courseTraineeService = courseTraineeService;
        }



        [HttpGet]
        public List<CourseTrainee> GetAllCourseTrainee()
        {
            return _courseTraineeService.GetAllCourseTrainee();
        }




        [HttpPost]
        [Route("Create")]
        public bool CreateCourseTrainee(CourseTrainee courseTrainee)
        {
            return _courseTraineeService.CreateCourseTrainee(courseTrainee);
        }



        [HttpPut]
        [Route("Update")]
        public bool UdateCourseTrainee(CourseTrainee courseTrainee)
        {
            return _courseTraineeService.UdateCourseTrainee(courseTrainee);
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCourseTrainee(int id)
        {
            return _courseTraineeService.DeleteCourseTrainee(id);
        }




        [HttpGet]
        [Route("GetById/{id}")]
        public CourseTrainee GetCourseTraineeById(int id)
        {
            return _courseTraineeService.GetCourseTraineeById(id);
        }

        [HttpGet]
        [Route("GetUserCourse/{id}")]
        public List<DTO> GetAllUser(int id)
        {
            return _courseTraineeService.GetAllUser(id);
        }

        [HttpGet]
        [Route("GetCoursesUser/{id}")]
        public List<DTOC> GetAllCourses(int id)
        {
            return _courseTraineeService.GetAllCourses(id);
        }
    }
}
