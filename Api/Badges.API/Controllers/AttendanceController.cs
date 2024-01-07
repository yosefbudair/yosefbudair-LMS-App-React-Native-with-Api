using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Badges.Core.Data;
using Badges.Core.Services;

namespace Badges.Api.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public List<Attendance> GetAllAttendance()
        {
            return _attendanceService.GetAllAttendance();
        }

        [HttpPost]
        public bool CreateAttendance(Attendance attendance)
        {
            return _attendanceService.CreateAttendance(attendance);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateAttendance(Attendance attendance)
        {
            return _attendanceService.UpdateAttendance(attendance);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteAttendance(int id)
        {
            return _attendanceService.DeleteAttendance(id);
        }

        [HttpGet]
        [Route("GetAttendanceById/{id}")]
        public Attendance GetAttendanceById(int id)
        {
            return _attendanceService.GetAttendanceById(id);
        }

        [HttpGet]
        [Route("GetattendanceCourse/{id}")]
        public List<DTOAttendance> GetattendanceCourse(int id)
        {
            return _attendanceService.GetattendanceCourse(id);
        }
    }
}
