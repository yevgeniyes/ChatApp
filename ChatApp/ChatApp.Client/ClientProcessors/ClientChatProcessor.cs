using NFX;
using NFX.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ChatApp.Client.ClientServices;

namespace ChatApp.Client
{
    class ClientChatProcessor
    {
        [Config("$test-service-node")]
        private string m_TestServiceNode;

        public ClientChatProcessor()
        {
            Console.WriteLine("CHAT INTRO TEXT\n");
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }


        public void StartChat(string name, Guid token)
        {
            //запуск фонового потока здесь
            MessageRequestProcessor backgrounRequst = new MessageRequestProcessor();
            Thread backgroundThread = new Thread(backgrounRequst.Start);
            backgroundThread.Start();

            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                string message = inputProc.ReadMessageInput(name);

                try
                {
                    using (var client = new ChatServiceClient(m_TestServiceNode))
                    {
                        if (client.PutMessage(token, message))
                        {
                            //_clientChatSession.Add(name + ": " + message);
                        }
                        else
                        {
                            Console.WriteLine("\nCurrent session was lost. Re-login to continue\n");
                            ClientLoginProcessor login = new ClientLoginProcessor();
                            login.Run();
                        }
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
