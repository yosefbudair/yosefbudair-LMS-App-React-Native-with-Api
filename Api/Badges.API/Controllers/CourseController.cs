using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Badges.Core.Data;
using Badges.Core.Services;

namespace Badges.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService coursService)
        {
            _courseService = coursService;
        }



        [HttpGet]
        public List<Course> GetAllCourses()
        {
            return _courseService.GetAllCourses();
        }




        [HttpPost]
        [Route("Create")]
        public bool CREATECourse(Course course)
        {
            return _courseService.CREATECourse(course);
        }



        [HttpPut]
        [Route("Update")]
        public bool UPDATECourse(Course course)
        {
            return _courseService.UPDATECourse(course);
        }



        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCourse(int id)
        {
            return _courseService.DeleteCourse(id);
        }




        [HttpGet]
        [Route("GetById/{id}")]
        public Course GetCourseById(int id)
        {
            return _courseService.GetCourseById(id);
        }
    }
}
