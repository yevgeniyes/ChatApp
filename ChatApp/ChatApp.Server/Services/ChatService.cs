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
        private object threadLock = new object();

        public bool PutMessage(Guid token, string message)
        {
            lock (threadLock)
            {
                AuthenticationProcessor auth = new AuthenticationProcessor();
                var name = auth.ValidateNameByToken(token);
                if (name != null)
                {
                    Message newMessage = new Message();
                    newMessage.Id = ServerContext.ChatSession.Count + 1;
                    newMessage.Name = name;
                    newMessage.Time = DateTime.Now;
                    newMessage.Content = message;
                    ServerContext.ChatSession.Add(newMessage);
                    return true;
                }
                return false;
            }
        }
    }
}
