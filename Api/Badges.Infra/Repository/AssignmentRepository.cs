using System.Data;
using Dapper;
using Badges.Core.Common;
using Badges.Core.Data;
using Badges.Core.Repository;

namespace Badges.Infra.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly IDbContext _dbContext;

        public AssignmentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }       

        public List<Assignment> GetAllAssignments() {


            IEnumerable<Assignment> result = _dbContext.Connection.Query<Assignment>("Assignments_Package.GetAllAssignments", commandType: CommandType.StoredProcedure);            
            return result.ToList();
        
        }

        public bool CreateAssignments(Assignment assignment)
        {   
            
            var create = new DynamicParameters();
            create.Add("DateC", assignment.Datecreate, dbType : DbType.Date , direction: ParameterDirection.Input);
            create.Add("DL", assignment.Deadline, dbType: DbType.Date, direction: ParameterDirection.Input);
            create.Add("AName", assignment.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("MK", assignment.Mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("Des", assignment.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("CID", assignment.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("ASSIGNMENTS_PACKAGE.CREATEAssignments", create ,commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool UpdateAssignments(Assignment assignment)
        {

            var update = new DynamicParameters();
            update.Add("AID", assignment.Assignmentsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("DateC", assignment.Datecreate, dbType: DbType.Date, direction: ParameterDirection.Input);
            update.Add("DL", assignment.Deadline, dbType: DbType.Date, direction: ParameterDirection.Input);
            update.Add("AName", assignment.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("MK", assignment.Mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("Des", assignment.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("CID", assignment.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Assignments_Package.UPDATEAssignments", update, commandType: CommandType.StoredProcedure);


            return result > 0;
        }
        

        public bool DeleteAssignments(int id)
        {

            var delete = new DynamicParameters();
            delete.Add("AID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            
            var result = _dbContext.Connection.Execute("Assignments_Package.DeleteAssignments", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public Assignment GetAssignmentsById(int id)
        {

            var get = new DynamicParameters();
            get.Add("AID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Assignment>("Assignments_Package.GetAssignmentsById", get, commandType: CommandType.StoredProcedure);

            

           return result.FirstOrDefault()!;
        }
    }
}
