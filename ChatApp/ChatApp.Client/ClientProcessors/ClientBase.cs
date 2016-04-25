using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ChatApp.Client
{
    class ClientBase
    {
        protected static List<string> _clientChatSession = new List<string>();
        protected static string _clientName;
    }
}
