using System;
using NFX;
using NFX.Environment;
using ChatApp.Client.ClientServices;

namespace ChatApp.Client
{
    class ClientLoginProcessor : ClientBase
    {
        [Config("$test-service-node")]
        private string m_TestServiceNode;

        public ClientLoginProcessor()
        {
            Console.WriteLine(Messages.WELCOME_TEXT);
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        public void Run()
        {
            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                var name = inputProc.ReadLoginInput();

                if (name == null) continue;

                try
                {
                    using (var client = new LoginServiceClient(m_TestServiceNode))
                    {
                        var token = client.Login(name);
                        if (token != Guid.Empty)
                        {
                            Console.WriteLine("\nLogin successful\n");
                            _clientName = name;
                            Console.Clear();
                            ClientChatProcessor chat = new ClientChatProcessor();
                            chat.StartChat(token);
                        }
                        else Console.WriteLine(Messages.LOGIN_ERROR);
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
