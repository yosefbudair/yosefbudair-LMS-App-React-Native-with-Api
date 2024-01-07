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

namespace Badges.Infra.Repository
{
    public class BadgesTrRepository : IBadgesTrRepository
    {

        private readonly IDbContext _dbContext;

        public BadgesTrRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<BadgesTrainee> GetAllBadges()
        {
            IEnumerable<BadgesTrainee> result = _dbContext.Connection.Query<BadgesTrainee>("BadgesTr_Package.get_all", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool CreateBadgeTr(BadgesTrainee badge)
        {
            var create = new DynamicParameters();
            create.Add("CID", badge.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("UID", badge.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("AID", badge.Assignmentsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("BID", badge.Badgesid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("BadgesTr_Package.create_badgeTr", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool UpdateBadgeTr(BadgesTrainee badge)
        {
            var update = new DynamicParameters();
            update.Add("id", badge.Btid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("CID", badge.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("UID", badge.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("AID", badge.Assignmentsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("BID", badge.Badgesid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("BadgesTr_Package.update_badgeTr", update, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool DeleteBadgeTr(int id)
        {
            var delete = new DynamicParameters();
            delete.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("BadgesTr_Package.delete_badgeTr", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }
        public BadgesTrainee GetBadgeTrById(int id)
        {
            var get = new DynamicParameters();
            get.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<BadgesTrainee>("BadgesTr_Package.get_badgeTr_by_id", get, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault()!;
        }

    }
}
