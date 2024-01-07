using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Badges.Core.Data;
using Badges.Core.Services;

namespace Badges.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentTrController : ControllerBase
    {
        private readonly IAssignmentTraineeService _assignmentTrService;

        public AssignmentTrController(IAssignmentTraineeService assignmentTrService)
        {
            _assignmentTrService = assignmentTrService;
        }


        [HttpGet]
        public List<AssignmentsTrainee> GetAllAssigmentTrainee()
        {
            return _assignmentTrService.GetAllAssigmentTrainee();
        }


        [HttpPost]
        public bool CreateAssignmentTrainee(AssignmentsTrainee assignment)
        {
            return _assignmentTrService.CreateAssignmentTrainee(assignment);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateAssignmentTrainee(AssignmentsTrainee assignment)
        {
            return _assignmentTrService.UpdateAssignmentTrainee(assignment);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteAssignmentTrainee(int id) 
        { 
            return _assignmentTrService.DeleteAssignmentTrainee(id); 
        }

        [HttpGet]
        [Route("GetATById/{id}")]
        public AssignmentsTrainee GetAssignmentTraineeById(int id)
        {
            return _assignmentTrService.GetAssignmentTraineeById(id);
        }

        [HttpGet]
        [Route("GetAU/{Uid}/{Cid}")]
        public List<DTOAT> GetAllAssignmentUser(int Uid ,int Cid)
        {
            return _assignmentTrService.GetAllAssignmentUser(Uid,Cid);
        }
    }
}
