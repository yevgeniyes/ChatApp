using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Client
{
    class ClientInputProcessor
    {
        public string ReadLoginInput()
        {
            Console.Write("Enter your name: ");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(Messages.LOGIN_ERROR);
                return null;
            }
            if (input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                Console.WriteLine(Messages.LOGIN_ERROR);
                return null;
            }
            return input;
        }

        public string ReadMessageInput(string name)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(Messages.EMPTY_STRING);
                Console.Write(name + ": ");
                return null;
            }
            return input;
        }
    }
}
