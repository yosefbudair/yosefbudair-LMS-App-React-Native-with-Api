using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Services
{
    public interface IAttendanceTrService
    {
        public List<AttendanceTrainee> GetAllAttendanceTr();
        public bool CREATEAttendanceTr(AttendanceTrainee attendanceTr);
        public bool UPDATEAttendanceTr(AttendanceTrainee attendanceTr);
        public bool DeleteAttendanceTr(int id);
        public AttendanceTrainee GetAttendanceTrById(int id);
    }
}
