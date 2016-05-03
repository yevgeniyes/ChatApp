using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Contracts.Services;
using ChatApp.Contracts;

namespace ChatApp.Server.Services
{
    class MessageRequestService : IMessageRequestService
    {
        public List<Message> RequestMessages(Guid token, int lastMessageId)
        {
            List<Message> newMesseges = new List<Message>();
            string name;
            ServerContext._onlineUsers.TryGetValue(token, out name);
            if (name == null) return null;

            var count = ServerContext._serverChatSession.Count;
            if (lastMessageId != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (ServerContext._serverChatSession[i].id > lastMessageId)
                        newMesseges.Add(ServerContext._serverChatSession[i]);
                }
                return newMesseges;
            }
            else
            {
                if (ServerContext._serverChatSession.Any<Message>())
                {
                    for (int i = 0; i < count; i++)
                    {
                        newMesseges.Add(ServerContext._serverChatSession[i]);
                    }
                }
                return newMesseges;
            }
        }
    }
}
