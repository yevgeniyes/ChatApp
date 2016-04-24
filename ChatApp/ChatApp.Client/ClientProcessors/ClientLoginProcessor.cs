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
            Console.WriteLine("INTRO TEXT\n");
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        public void Run()
        {
            //try остановить поток
            try
            {
                //th.Abort();
            }
            catch
            {

            }

            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                var name = inputProc.ReadLoginInput();

                if (name == null) continue;

                //try
                //{
                    using (var client = new LoginServiceClient(m_TestServiceNode))
                    {
                        var token = client.Login(name);
                        if (token != Guid.Empty)
                        {
                            Console.WriteLine("Login successful");
                            ClientChatProcessor chat = new ClientChatProcessor();
                            chat.StartChat(name, token);
                        }
                        else Console.WriteLine("Login error");
                    }
                //}
                //catch (Exception error)
                //{
                //    Console.Write("\nServer error: ");
                //    Console.WriteLine(error.Message + "\n");
                //}
            }
        }
    }
}
