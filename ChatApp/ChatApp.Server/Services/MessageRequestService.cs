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
        private object threadLock = new object();

        public List<Message> RequestMessages(Guid token, int lastMessageId)
        {
            lock (threadLock)
            {
                AuthenticationProcessor auth = new AuthenticationProcessor();
                if (auth.ValidateNameByToken(token) != null)
                {
                    var newMesseges = ServerContext.ChatSession.Where(m => m.Id > lastMessageId).ToList<Message>();
                    return newMesseges;
                }
                else return null;
            }
        }
    }
}
