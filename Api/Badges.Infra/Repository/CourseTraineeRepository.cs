using Badges.Core.Common;
using Badges.Core.Data;
using Badges.Core.Repository;
using Dapper;
using System.Data;


namespace Badges.Infra.Repository
{
    public class CourseTraineeRepository: ICourseTraineeRepository
    {
        private readonly IDbContext _dbContext;

        public CourseTraineeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CourseTrainee> GetAllCourseTrainee()
        {
            IEnumerable<CourseTrainee> result = _dbContext.Connection.Query<CourseTrainee>("Course_Trainee_Package.get_all", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool CreateCourseTrainee(CourseTrainee courseTrainee)
        {
            var create = new DynamicParameters();
            create.Add("mk", courseTrainee.Mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("cid", courseTrainee.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("uid", courseTrainee.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Course_Trainee_Package.create_course_trainee", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool UdateCourseTrainee(CourseTrainee courseTrainee)
        {
            var update = new DynamicParameters();
            update.Add("id", courseTrainee.Ctid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("mk", courseTrainee.Mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("cid", courseTrainee.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("uid", courseTrainee.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Course_Trainee_Package.update_course_trainee", update, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool DeleteCourseTrainee(int id)
        {
            var delete = new DynamicParameters();
            delete.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Course_Trainee_Package.delete_course_trainee", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }
        public CourseTrainee GetCourseTraineeById(int id)
        {
            var get = new DynamicParameters();
            get.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<CourseTrainee>("Course_Trainee_Package.get_course_trainee_by_id", get, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault()!;
        }

        public List<DTO> GetAllUser(int id)
        {
            var get = new DynamicParameters();
            get.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<DTO> result = _dbContext.Connection.Query<DTO>("GetallUserforCourse", get, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<DTOC> GetAllCourses(int id)
        {
            var get = new DynamicParameters();
            get.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<DTOC> result = _dbContext.Connection.Query<DTOC>("GetallCoursesforUser", get, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}