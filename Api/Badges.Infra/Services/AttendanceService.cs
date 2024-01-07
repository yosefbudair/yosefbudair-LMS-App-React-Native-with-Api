using Badges.Core.Data;
using Badges.Core.Repository;
using Badges.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Infra.Services
{//
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        public List<Attendance> GetAllAttendance()
        {
            return _attendanceRepository.GetAllAttendance();
        }
        public bool CreateAttendance(Attendance attendance)
        {
            return _attendanceRepository.CreateAttendance(attendance);
        }
        public bool UpdateAttendance(Attendance attendance)
        {
            return _attendanceRepository.UpdateAttendance(attendance);
        }
        public bool DeleteAttendance(int id)
        {
            return _attendanceRepository.DeleteAttendance(id);
        }
        public Attendance GetAttendanceById(int id)
        {
            return _attendanceRepository.GetAttendanceById(id);
        }
        public List<DTOAttendance> GetattendanceCourse(int id)
        {
            return _attendanceRepository.GetattendanceCourse(id);
        }
    }
}
