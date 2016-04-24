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
    class MessageRequestProcessor : ClientBase
    {
        [Config("$test-service-node")]
        private string m_TestServiceNode;

        public MessageRequestProcessor()
        {
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        public void Start()
        {
            string lastMessage = null;

            while (true)
            {
                if (_clientChatSession.Any<string>())
                {
                    lastMessage = _clientChatSession.Last();
                }
                //try
                //{
                using (var client = new MessageServiceClient(m_TestServiceNode))
                {


                    List<string> newMessages = client.RequestMessages(lastMessage);
                    if (newMessages.Any<string>())
                    {
                        _clientChatSession.AddRange(newMessages);

                        foreach (string newMessage in newMessages)
                        {
                            Console.WriteLine(newMessage);
                        }
                    }
                }
                //}
                //catch (Exception error)
                //{
                //    Console.Write("\nServer error: ");
                //    Console.WriteLine(error.Message + "\n");
                //}
                Thread.Sleep(2000);
            }
        }
    }
}
