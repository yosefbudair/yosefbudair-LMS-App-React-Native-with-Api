using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Badges.Core.Repository
{
    public interface IAssignmentTrainee_Repository
    {
        public List<AssignmentsTrainee> GetAllAssigmentTrainee();
        public bool CreateAssignmentTrainee(AssignmentsTrainee assignment);
        public bool UpdateAssignmentTrainee(AssignmentsTrainee assignment);
        public bool DeleteAssignmentTrainee(int id);
        public AssignmentsTrainee GetAssignmentTraineeById(int id);
        public List<DTOAT> GetAllAssignmentUser(int Uid, int Cid);

    }
}
