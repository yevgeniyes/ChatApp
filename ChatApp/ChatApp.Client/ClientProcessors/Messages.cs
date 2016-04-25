using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Client
{
    public class Messages
    {
        public const string WELCOME_TEXT = ":::::::::::::::::::::::::::::::::::::::::::::::\n::::::::::::WELCOME TO CHATAPP 1.0!::::::::::::\n::::::::::::LOGIN TO START CHATTING::::::::::::\n:::::::::::::::::::::::::::::::::::::::::::::::\n\nUse registred names: zero, alpha, smoke, xman \n";
        public const string LOGIN_ERROR = "\nLogin error. Please check the name and try again\n";
        public const string EMPTY_STRING = "\nThere is no any message here... Write something and try again\n";
        public const string CHAT_HEADER = ":::::::::::::::::::::::::::::::::::::::::::::::\n:::::::::::::::::CHAT STARTED!:::::::::::::::::\n::::::::::::::::YOU ARE ONLINE:::::::::::::::::\n:::::::::::::::::::::::::::::::::::::::::::::::\n";
        public const string SESSION_LOST = "\nCurrent session was lost. Re-login to continue\n";
    }
}
