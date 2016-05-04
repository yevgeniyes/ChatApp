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

                newMessage.id = Properties.Settings.Default.serverLastMessageID + 1;
                newMessage.name = name;
                newMessage.time = DateTime.Now;
                newMessage.content = message;
                ServerContext._serverChatSession.Add(newMessage);

                //saving last message ID in settings
                Properties.Settings.Default.serverLastMessageID = newMessage.id;
                Properties.Settings.Default.Save();

                return true;
            }
            return false;
        }
    }
}
