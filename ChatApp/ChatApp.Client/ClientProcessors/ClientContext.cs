using System;
using System.Collections.Generic;
using ChatApp.Contracts;

namespace ChatApp.Client
{
    static class ClientContext
    {
        private readonly static List<Message> _clientChatSession = new List<Message>();
        private static string _clientName;
        private static Guid _token;

        public static List<Message> ChatSession
        {
            get { return _clientChatSession; }
        }
        public static string Name
        {
            get { return _clientName; }
            set { _clientName = value; }
        }
        public static Guid Token
        {
            get { return _token; }
            set { _token = value; }
        }
    }
}
