using Badges.Core.Data;
using Badges.Core.Repository;
using Badges.Core.Services;


namespace Badges.Infra.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public List<Assignment> GetAllAssignments()
        {
            return _assignmentRepository.GetAllAssignments();
        }
        public bool CreateAssignments(Assignment assignment) 
        {
            return _assignmentRepository.CreateAssignments(assignment); 
        }

        public bool UpdateAssignments(Assignment assignment) 
        { 
            return _assignmentRepository.UpdateAssignments(assignment);
        }
        public bool DeleteAssignments(int id)
        {
            return _assignmentRepository.DeleteAssignments(id);
        }
        public Assignment GetAssignmentsById(int id) 
        { 
            return _assignmentRepository.GetAssignmentsById(id); 
        }
    }
}
