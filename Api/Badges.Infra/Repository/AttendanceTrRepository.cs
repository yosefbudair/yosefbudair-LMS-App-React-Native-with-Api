using Badges.Core.Common;
using Badges.Core.Data;
using Badges.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Badges.Infra.Repository
{
    public class AttendanceTrRepository:IAttendanceTrRepository
    {
        private readonly IDbContext _dbContext;

        public AttendanceTrRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AttendanceTrainee> GetAllAttendanceTr()
        {

            IEnumerable<AttendanceTrainee> result = _dbContext.Connection.Query<AttendanceTrainee>("AttendanceTR_Package.GetAllAttendanceTr", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool CREATEAttendanceTr(AttendanceTrainee attendanceTr)
        {

            var create = new DynamicParameters();

            create.Add("ADate", attendanceTr.Attendantedate, dbType: DbType.Date, direction: ParameterDirection.Input);
            create.Add("CheckA", attendanceTr.Checkat, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("AID", attendanceTr.Attendanceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("UID", attendanceTr.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("AttendanceTR_Package.CREATEAttendanceTr", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool UPDATEAttendanceTr(AttendanceTrainee attendanceTr)
        {

            var update = new DynamicParameters();
            update.Add("ID", attendanceTr.Atid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("ADate", attendanceTr.Attendantedate, dbType: DbType.Date, direction: ParameterDirection.Input);
            update.Add("CheckA", attendanceTr.Checkat, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("AID", attendanceTr.Attendanceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("UID", attendanceTr.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("AttendanceTR_Package.UPDATEAttendanceTr", update, commandType: CommandType.StoredProcedure);


            return result > 0;
        }


        public bool DeleteAttendanceTr(int id)
        {

            var delete = new DynamicParameters();
            delete.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("AttendanceTR_Package.DeleteAttendanceTr", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public AttendanceTrainee GetAttendanceTrById(int id)
        {

            var get = new DynamicParameters();
            get.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<AttendanceTrainee>("AttendanceTR_Package.GetAttendanceTrById", get, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault()!;
        }

    }
}

