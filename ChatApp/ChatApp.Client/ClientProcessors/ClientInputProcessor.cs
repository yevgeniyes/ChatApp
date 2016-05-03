using System;

namespace ChatApp.Client
{
    class ClientInputProcessor
    {
        public string ReadLoginInput()
        {
            Console.Write("Enter your name or register: ");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(UIMessages.LOGIN_ERROR);
                return null;
            }
            if (input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                Console.WriteLine(UIMessages.LOGIN_ERROR);
                return null;
            }

            return input;
        }

        public string ReadRegistrationInput()
        {
            Console.Write("Enter new name: ");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(UIMessages.REG_ERROR);
                return null;
            }
            if (input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
            {
                Console.WriteLine(UIMessages.REG_ERROR);
                return null;
            }
            if (input == "reg")
            {
                Console.WriteLine(UIMessages.REG_ERROR);
                return null;
            }
            return input;
        }

        public string ReadMessageInput()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(UIMessages.EMPTY_STRING);
                return null;
            }
            Console.CursorTop -= 1;
            return input;
        }
    }
}
