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
    public class CourseTraineeService: ICourseTraineeService
    {
        private readonly ICourseTraineeRepository _courseTraineeRepository;

        public CourseTraineeService(ICourseTraineeRepository courseTraineeRepository)
        {
            _courseTraineeRepository = courseTraineeRepository;
        }
        public List<CourseTrainee> GetAllCourseTrainee() { return _courseTraineeRepository.GetAllCourseTrainee(); }
        public bool CreateCourseTrainee(CourseTrainee courseTrainee) { return _courseTraineeRepository.CreateCourseTrainee(courseTrainee); }
        public bool UdateCourseTrainee(CourseTrainee CourseTrainee) { return _courseTraineeRepository.UdateCourseTrainee(CourseTrainee); }
        public bool DeleteCourseTrainee(int id) { return _courseTraineeRepository.DeleteCourseTrainee(id); }
        public CourseTrainee GetCourseTraineeById(int id) { return _courseTraineeRepository.GetCourseTraineeById(id); }
        public List<DTO> GetAllUser(int id) { return _courseTraineeRepository.GetAllUser(id); }
        public List<DTOC> GetAllCourses(int id) { return _courseTraineeRepository.GetAllCourses(id); }
    }
}
