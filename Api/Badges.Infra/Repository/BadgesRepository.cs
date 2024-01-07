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
    public class BadgesRepository:IBadgesRepository
    {
        private readonly IDbContext _dbContext;

        public BadgesRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Badge> GetAllBadges()
        {
            IEnumerable<Badge> result = _dbContext.Connection.Query<Badge>("Badges_Package.get_all", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool CreateBadge(Badge badge)
        {
            var create = new DynamicParameters();
            create.Add("tp", badge.Type, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("tx", badge.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("img",badge.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("CT", badge.Criteria, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("ACT", badge.Activecriteria, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Badges_Package.create_badge", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool UdateBadge(Badge badge)
        {
            var update = new DynamicParameters();
            update.Add("id", badge.Badgesid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("tp", badge.Type, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("tx", badge.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("img", badge.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("CT", badge.Criteria, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("ACT", badge.Activecriteria, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Badges_Package.update_badge", update, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool DeleteBadge(int id) 
        {
            var delete = new DynamicParameters();
            delete.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Badges_Package.delete_badge", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }
        public Badge GetBadgeById(int id) {
            var get = new DynamicParameters();
            get.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Badge>("Badges_Package.get_badge_by_id", get, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault()!;
        }
    }
}
