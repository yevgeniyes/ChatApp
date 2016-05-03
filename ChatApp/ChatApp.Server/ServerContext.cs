using System;
using System.Collections.Generic;
using ChatApp.Contracts;

namespace ChatApp.Server
{
    static class ServerContext
    {
        public static List<string> _registredUsers = new List<string>() { "zero", "alpha", "smoke", "xman" };
        public static Dictionary<Guid, string> _onlineUsers = new Dictionary<Guid, string>();
        public static List<Message> _serverChatSession = new List<Message>();
    }
}
