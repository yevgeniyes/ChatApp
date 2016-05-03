using System;
using System.Collections.Generic;
using ChatApp.Contracts;

namespace ChatApp.Client
{
    static class ClientContext
    {
        public static List<Message> _clientChatSession = new List<Message>();
        public static string _clientName;
        public static Guid _token;
    }
}
