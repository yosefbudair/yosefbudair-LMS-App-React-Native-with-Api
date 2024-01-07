using Dapper;
using Badges.Core.Common;
using Badges.Core.Data;
using Badges.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Infra.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly IDbContext _dbContext;

        public CourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CREATECourse(Course Course)
        {

            var create = new DynamicParameters();
            create.Add("cdateFrom", Course.Datefrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            create.Add("cdateto", Course.Dateto, dbType: DbType.Date, direction: ParameterDirection.Input);
            create.Add("cname", Course.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("cDuration", Course.Duration, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("CsectionNum", Course.Sectionnum, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("Cimage", Course.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("userCID", Course.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("Cnum", Course.Coursenum, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = _dbContext.Connection.Execute("Course_Package.CREATECourse", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool DeleteCourse(int id)
        {
            var delete = new DynamicParameters();
            delete.Add("cId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Course_Package.DeleteCourse", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public List<Course> GetAllCourses()
        {
            IEnumerable<Course> result = _dbContext.Connection.Query<Course>("Course_Package.GetAllCourses", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Course GetCourseById(int id)
        {
            var get = new DynamicParameters();
            get.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Course>("Course_Package.GetCourseById", get, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault()!;
        }

        public bool UPDATECourse(Course Course)
        {

            var update = new DynamicParameters();
            update.Add("CID", Course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("cdateFrom", Course.Datefrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            update.Add("cdateto", Course.Dateto, dbType: DbType.Date, direction: ParameterDirection.Input);
            update.Add("cname", Course.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("cDuration", Course.Duration, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("CsectionNum", Course.Sectionnum, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("Cimage", Course.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("userCID", Course.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("Cnum", Course.Coursenum, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = _dbContext.Connection.Execute("Course_Package.UPDATECourse", update, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}
