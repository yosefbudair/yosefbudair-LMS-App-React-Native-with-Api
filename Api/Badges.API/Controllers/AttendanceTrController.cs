using Badges.Core.Data;
using Badges.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badges.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceTrController : ControllerBase
    {
        private readonly IAttendanceTrService _attendanceTrService;

        public AttendanceTrController(IAttendanceTrService attendanceTrService)
        {
            _attendanceTrService = attendanceTrService;
        }

        [HttpGet]
        public List<AttendanceTrainee> GetAllAttendanceTr()
        {
            return _attendanceTrService.GetAllAttendanceTr();
        }

        [HttpPost]
        public bool CREATEAttendanceTr(AttendanceTrainee attendanceTr)
        {
            return _attendanceTrService.CREATEAttendanceTr(attendanceTr);
        }

        [HttpPut]
        [Route("Update")]
        public bool UPDATEAttendanceTr(AttendanceTrainee attendanceTr)
        {
            return _attendanceTrService.UPDATEAttendanceTr(attendanceTr);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteAttendanceTr(int id)
        {
            return _attendanceTrService.DeleteAttendanceTr(id);
        }

        [HttpGet]
        [Route("GetAtTrById/{id}")]
        public AttendanceTrainee GetAttendanceTrById(int id)
        {
            return _attendanceTrService.GetAttendanceTrById(id);
        }
    }
}
