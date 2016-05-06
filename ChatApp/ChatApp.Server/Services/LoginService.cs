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
        private object threadLock = new object();

        public Guid Login(string name)
        {
            lock (threadLock)
            {
                foreach (string user in ServerContext.RegistredUsers)
                {
                    if (name == user)
                    {
                        ICollection<string> onlineUsers = ServerContext.OnlineUsers.Values;
                        foreach (string onlineUser in onlineUsers)
                        {
                            if (name == onlineUser)
                                return Guid.Empty;
                        }
                        var token = Guid.NewGuid();
                        ServerContext.OnlineUsers.Add(token, name);
                        return token;
                    }
                }
                return Guid.Empty;
            }
        }
    }
}
