using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Contracts.Services;

namespace ChatApp.Server.Services
{
    class MessageRequestService : ServerBase, IMessageRequestService
    {
        public List<string> RequestMessages(string lastMessage)
        {
            List<string> newMesseges = new List<string>();

            if (lastMessage != null)
            {
                var index = _serverChatSession.LastIndexOf(lastMessage);
                var count = _serverChatSession.Count;
                if (count - index > 1)
                {
                    for (int i = index + 1; i < count; i++)
                    {
                        newMesseges.Add(_serverChatSession[i]);
                    }

                }
                return newMesseges;
            }
            else
            {
                if (_serverChatSession.Any<string>())
                {
                    string message = _serverChatSession.Last();
                    newMesseges.Add(message);
                }
                return newMesseges;
            }
        }
    }
}
