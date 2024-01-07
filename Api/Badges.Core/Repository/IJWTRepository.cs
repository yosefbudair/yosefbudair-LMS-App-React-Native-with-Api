using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badges.Core.Data;

namespace Badges.Core.Repository
{
    public interface IJWTRepository
    {
        public User UserLogin(User login);

    }
}
