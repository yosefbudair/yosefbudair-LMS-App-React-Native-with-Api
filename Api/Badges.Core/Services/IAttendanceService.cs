using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Services
{//
    public interface IAttendanceService
    {
        public List<Attendance> GetAllAttendance();
        public bool CreateAttendance(Attendance attendance);
        public bool UpdateAttendance(Attendance attendance);
        public bool DeleteAttendance(int id);
        public Attendance GetAttendanceById(int id);
        public List<DTOAttendance> GetattendanceCourse(int id);
    }
}
