using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourses();

        public bool CREATECourse(Course Course);
        public bool UPDATECourse(Course Course);
        public bool DeleteCourse(int id);
        public Course GetCourseById(int id);

    }
}
