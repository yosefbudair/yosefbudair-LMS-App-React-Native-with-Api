using Badges.Core.Data;
using Badges.Core.Repository;
using Badges.Core.Services;
using Badges.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Infra.Services
{
    public class AssignmentTrainee_Service : IAssignmentTraineeService
    {
        private readonly IAssignmentTrainee_Repository _assignmentTrRepository;

        public AssignmentTrainee_Service(IAssignmentTrainee_Repository assignmentTrRepository)
        {
            _assignmentTrRepository = assignmentTrRepository;
        }
        public List<AssignmentsTrainee> GetAllAssigmentTrainee()
        {
            return _assignmentTrRepository.GetAllAssigmentTrainee();
        }
        public bool CreateAssignmentTrainee(AssignmentsTrainee assignment)
        {
            return _assignmentTrRepository.CreateAssignmentTrainee(assignment);
        }
        public bool UpdateAssignmentTrainee(AssignmentsTrainee assignment)
        {
            return _assignmentTrRepository.UpdateAssignmentTrainee(assignment);
        }
        public bool DeleteAssignmentTrainee(int id)
        {
            return _assignmentTrRepository.DeleteAssignmentTrainee(id);
        }
        public AssignmentsTrainee GetAssignmentTraineeById(int id)
        {
            return _assignmentTrRepository.GetAssignmentTraineeById(id);
        }

        public List<DTOAT> GetAllAssignmentUser(int Uid, int Cid)
        {
            return _assignmentTrRepository.GetAllAssignmentUser(Uid , Cid);
        }

    }
}
