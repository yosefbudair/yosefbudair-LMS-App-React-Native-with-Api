using Dapper;
using Badges.Core.Common;
using Badges.Core.Data;
using Badges.Core.Repository;
using System.Data;


namespace Badges.Infra.Repository
{//
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IDbContext _dbContext;

        public AttendanceRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Attendance> GetAllAttendance()
        {

            IEnumerable<Attendance> result = _dbContext.Connection.Query<Attendance>("Attendance_Package.GetAllAttendance", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool CreateAttendance(Attendance attendance)
        {

            var create = new DynamicParameters();
            create.Add("CID", attendance.Courseid, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Attendance_Package.CREATEAttendance", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool UpdateAttendance(Attendance attendance)
        {

            var update = new DynamicParameters();
            update.Add("AID", attendance.Attendanceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("CID", attendance.Courseid, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Attendance_Package.UPDATEAttendance", update, commandType: CommandType.StoredProcedure);


            return result > 0;
        }


        public bool DeleteAttendance(int id)
        {

            var delete = new DynamicParameters();
            delete.Add("AID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Attendance_Package.DeleteAttendance", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public Attendance GetAttendanceById(int id)
        {

            var get = new DynamicParameters();
            get.Add("AID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Attendance>("Attendance_Package.GetAttendanceById", get, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault()!;
        }

        public List<DTOAttendance> GetattendanceCourse(int id)
        {
            var get = new DynamicParameters();
            get.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<DTOAttendance> result = _dbContext.Connection.Query<DTOAttendance>("GetallAttendanceForCourse", get, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
