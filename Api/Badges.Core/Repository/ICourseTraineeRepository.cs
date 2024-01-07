using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Repository
{
    public interface ICourseTraineeRepository
    {
        public List<CourseTrainee> GetAllCourseTrainee();
        public bool CreateCourseTrainee(CourseTrainee courseTrainee);
        public bool UdateCourseTrainee(CourseTrainee CourseTrainee);
        public bool DeleteCourseTrainee(int id);
        public CourseTrainee GetCourseTraineeById(int id);
        public List<DTO> GetAllUser(int id);
        public List<DTOC> GetAllCourses(int id);
    }
}
