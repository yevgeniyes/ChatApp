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
            Console.WriteLine("Enter the name:");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error");
                return null;
            }
            if (input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                Console.WriteLine("Error");
                return null;
            }
            return input;
        }

        public string ReadMessageInput(string name)
        {
            Console.Write(name + ": ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error");
                return null;
            }
            return input;
        }
    }
}
