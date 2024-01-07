using Dapper;
using Badges.Core.Common;
using Badges.Core.Data;
using Badges.Core.Repository;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Badges.Infra.Repository
{
    public class AssignmentTrainee_Repository : IAssignmentTrainee_Repository
    {
        private readonly IDbContext _dbContext;

        public AssignmentTrainee_Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AssignmentsTrainee> GetAllAssigmentTrainee()
        {


            IEnumerable<AssignmentsTrainee> result = _dbContext.Connection.Query<AssignmentsTrainee>("ASSIGNMENTS_TR_Package.GetAllAssignmentsTr", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool CreateAssignmentTrainee(AssignmentsTrainee assignment)
        {

            var create = new DynamicParameters();
            create.Add("SDate", assignment.Submitdate , dbType: DbType.Date, direction: ParameterDirection.Input);
            create.Add("MK", assignment.Mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("AID", assignment.Assignmentsid, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("UID", assignment.Userid, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("Url", assignment.Assignmenturl, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("ASSIGNMENTS_TR_Package.CREATEAssignmentsTr", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool UpdateAssignmentTrainee(AssignmentsTrainee assignment)
        {

            var update = new DynamicParameters();
            update.Add("ATranieeID", assignment.Atid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("SDate", assignment.Submitdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            update.Add("MK", assignment.Mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("AID", assignment.Assignmentsid, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("UID", assignment.Userid, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("Url", assignment.Assignmenturl, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("ASSIGNMENTS_TR_Package.UPDATEAssignmentsTr", update, commandType: CommandType.StoredProcedure);


            return result > 0;
        }


        public bool DeleteAssignmentTrainee(int id)
        {

            var delete = new DynamicParameters();
            delete.Add("ATranieeID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("ASSIGNMENTS_TR_Package.DeleteAssignmentsTr", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public AssignmentsTrainee GetAssignmentTraineeById(int id)
        {

            var get = new DynamicParameters();
            get.Add("ATranieeID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<AssignmentsTrainee>("ASSIGNMENTS_TR_Package.GetAssignmentsTrById", get, commandType: CommandType.StoredProcedure);



            return result.FirstOrDefault()!;
        }

        public List<DTOAT> GetAllAssignmentUser (int Uid, int Cid)
        {   
            var get = new DynamicParameters();
            get.Add("UId", Uid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            get.Add("CId", Cid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<DTOAT> result = _dbContext.Connection.Query<DTOAT>("GetallAssignmentsForUser", get , commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

    }
}
