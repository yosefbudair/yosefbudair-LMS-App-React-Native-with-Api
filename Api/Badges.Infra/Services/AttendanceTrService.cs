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
    public class AttendanceTrService:IAttendanceTrService
    {
        private readonly IAttendanceTrRepository _attendanceTrRepository;

        public AttendanceTrService(IAttendanceTrRepository attendanceTrRepository)
        {
            _attendanceTrRepository = attendanceTrRepository;
        }
        public List<AttendanceTrainee> GetAllAttendanceTr()
        {
            return _attendanceTrRepository.GetAllAttendanceTr();
        }
        public bool CREATEAttendanceTr(AttendanceTrainee attendanceTr)
        {
            return _attendanceTrRepository.CREATEAttendanceTr(attendanceTr);
        }
        public bool UPDATEAttendanceTr(AttendanceTrainee attendanceTr)
        {
            return _attendanceTrRepository.UPDATEAttendanceTr(attendanceTr);
        }
        public bool DeleteAttendanceTr(int id)
        {
            return _attendanceTrRepository.DeleteAttendanceTr(id);
        }
        public AttendanceTrainee GetAttendanceTrById(int id)
        {
            return _attendanceTrRepository.GetAttendanceTrById(id);
        }
    }

   
}
