using System;
using NFX;
using NFX.Environment;
using ChatApp.Client.ClientServices;

namespace ChatApp.Client
{
    class ClientLoginProcessor
    {
        [Config("$test-service-node")]
        private string m_ChatServiceNode;

        public ClientLoginProcessor()
        {
            Console.WriteLine(UIMessages.WELCOME_TEXT);
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        public void Run()
        {
            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                var name = inputProc.ReadLoginInput();
                if (name == null) continue;

                if (name == "reg")
                {
                    var regInput = inputProc.ReadRegistrationInput();
                    if (regInput == null) continue;

                    try
                    {
                        using (var client = new RegistrationServiceClient(m_ChatServiceNode))
                        {
                            if (!client.Register(regInput))
                            {
                                Console.WriteLine(UIMessages.REG_FAILURE);
                                continue;
                            }
                            else
                            {
                                Console.WriteLine(UIMessages.REG_SUCCESS);
                                continue;
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        Console.Write("\nServer error: ");
                        Console.WriteLine(error.Message + "\n");
                        continue;
                    }
                }

                try
                {
                    using (var client = new LoginServiceClient(m_ChatServiceNode))
                    {
                        var token = client.Login(name);
                        if (token != Guid.Empty)
                        {
                            Console.WriteLine("\nLogin successful\n");
                            ClientContext._clientName = name;
                            ClientContext._token = token;
                            Console.Clear();
                            ClientChatProcessor chat = new ClientChatProcessor();
                            chat.StartChat();
                        }
                        else Console.WriteLine(UIMessages.LOGIN_ERROR);
                    }
                }
                catch (Exception error)
                {
                    Console.Write("\nServer error: ");
                    Console.WriteLine(error.Message + "\n");
                }
            }
        }
    }
}
