using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Services
{
    public interface IJWTService
    {
        public string userLogin(User login);
    }
}
