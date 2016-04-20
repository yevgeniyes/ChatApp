using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Server
{
    class TokenGenerator
    {
        public string GetToken(Random random)
        {
            string[] simbols = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "q", "w", "e", "r", "t", "y",
            "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m"};

            string token = "token_";
            int tokenLength = 30;

            for (int i = 0; i <= tokenLength; i++)
            {
                token += simbols[random.Next(simbols.Length)];
            }
            return token;
        }
    }
}
