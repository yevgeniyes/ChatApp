using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Server
{
    class AuthenticationProcessor
    {
        public string ValidateNameByToken(Guid token)
        {
            string name;
            ServerContext.OnlineUsers.TryGetValue(token, out name);
            return name;
        }
    }
}
