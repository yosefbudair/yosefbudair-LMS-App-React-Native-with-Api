using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Badges.Core.Data;
using Badges.Core.Repository;
using Badges.Core.Services;

namespace Badges.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {

        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public List<Assignment> GetAllAssignments()
        {
            return _assignmentService.GetAllAssignments();
        }
        [HttpPost]
        public bool CreateAssignments(Assignment assignment)
        {
            return _assignmentService.CreateAssignments(assignment);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateAssignments(Assignment assignment)
        {
            return _assignmentService.UpdateAssignments(assignment);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteAssignments(int id)
        {
            return _assignmentService.DeleteAssignments(id);
        }

        [HttpGet]
        [Route("GetAssignmentById/{id}")]
        public Assignment GetAssignmentsById(int id)
        {
            return _assignmentService.GetAssignmentsById(id);
        }
    }
}
