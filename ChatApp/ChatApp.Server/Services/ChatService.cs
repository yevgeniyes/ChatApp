using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Contracts.Services;

namespace ChatApp.Server.Services
{
    class ChatService : ServerBase, IChatService
    {
        public bool PutMessage(Guid token, string message)
        {
            string name;
            _onlineUsers.TryGetValue(token, out name);
            if (name != null)
            {
                _serverChatSession.Add(name + " (" + DateTime.Now + "): " + message);
                return true;
            }
            return false;
        }
    }
}
