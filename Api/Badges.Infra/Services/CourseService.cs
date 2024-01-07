using Badges.Core.Data;
using Badges.Core.Repository;
using Badges.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Infra.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool CREATECourse(Course Course)
        {
           return _courseRepository.CREATECourse(Course);
        }

        public bool DeleteCourse(int id)
        {
            return _courseRepository.DeleteCourse(id);
        }

        public List<Course> GetAllCourses()
        {
            return _courseRepository.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return _courseRepository.GetCourseById(id);
        }

        public bool UPDATECourse(Course Course)
        {
           return _courseRepository.UPDATECourse(Course);
        }
    }
}
