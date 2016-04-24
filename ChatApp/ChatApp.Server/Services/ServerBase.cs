using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Contracts.Services;

namespace ChatApp.Server.Services
{
    class ServerBase
    {
        protected static List<string> _registredUsers = new List<string>() { "zero", "alpha", "smoke", "xman" };
        protected static Dictionary<Guid, string> _onlineUsers = new Dictionary<Guid, string>();
        protected static List<string> _serverChatSession = new List<string>();
    }
}
