using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Contracts.Services;

namespace ChatApp.Server.Services
{
    class LoginService : ILoginService
    {
        public Guid Login(string name)
        {
            foreach (string user in ServerContext._registredUsers)
            {
                if(name == user)
                {
                    ICollection<string> onlineUsers = ServerContext._onlineUsers.Values;
                    foreach (string onlineUser in onlineUsers)
                    {
                        if (name == onlineUser)
                            return Guid.Empty;
                    }
                    var token = Guid.NewGuid();
                    ServerContext._onlineUsers.Add(token, name);
                    return token;
                }
            }
            return Guid.Empty;
        }
    }
}
