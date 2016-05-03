using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Contracts.Services;
using ChatApp.Contracts;

namespace ChatApp.Server.Services
{
    class ChatService : IChatService
    {
        public bool PutMessage(Guid token, string message)
        {
            string name;
            ServerContext._onlineUsers.TryGetValue(token, out name);
            if (name != null)
            {
                Message newMessage = new Message();
                newMessage.id = ServerContext._serverChatSession.Count + 1;
                newMessage.name = name;
                newMessage.time = DateTime.Now;
                newMessage.content = message;

                ServerContext._serverChatSession.Add(newMessage);
                return true;
            }
            return false;
        }
    }
}
