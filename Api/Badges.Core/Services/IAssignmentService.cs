using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Services
{
    public interface IAssignmentService
    {
        List<Assignment> GetAllAssignments();
        bool CreateAssignments(Assignment assignment);
        bool UpdateAssignments(Assignment assignment);
        bool DeleteAssignments(int id);
        Assignment GetAssignmentsById(int id);
    }
}
