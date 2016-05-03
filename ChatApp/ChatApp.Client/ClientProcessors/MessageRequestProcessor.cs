using NFX;
using NFX.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ChatApp.Client.ClientServices;
using ChatApp.Contracts;

namespace ChatApp.Client
{
    class MessageRequestProcessor
    {
        [Config("$test-service-node")]
        private string m_ChatServiceNode;

        public MessageRequestProcessor()
        {
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }

        public void Start()
        {
            int lastMessageId = 0;

            while (true)
            {
                if (ClientContext._clientChatSession.Any<Message>())
                {
                    lastMessageId = ClientContext._clientChatSession.Last().id;
                }
                try
                {
                    using (var client = new MessageServiceClient(m_ChatServiceNode))
                    {
                        List<Message> newMessages = client.RequestMessages(ClientContext._token, lastMessageId);

                        if (newMessages == null)
                        {
                            //Console.WriteLine(UIMessages.SESSION_LOST);
                            //ClientLoginProcessor login = new ClientLoginProcessor();
                            //login.Run();
                            //Thread.CurrentThread.Abort();
                            break;
                        }

                        if (newMessages.Any<Message>())
                        {
                            ClientContext._clientChatSession.AddRange(newMessages);

                            var buffer = 0;
                            for (int i = 0; i < newMessages.Count; i++)
                            {
                                Message message = newMessages[i];
                                var name = message.name;
                                var time = message.time.ToShortTimeString();
                                var content = message.content;

                                if (message.name != ClientContext._clientName)
                                {
                                    Console.MoveBufferArea(0, Console.CursorTop, Console.BufferWidth, 1, 0, Console.CursorTop + 1);
                                    buffer = Console.CursorLeft;
                                }

                                Console.CursorLeft = 0;
                                Console.WriteLine(name + ": " + content + " (" + time + ")");

                            }
                            Console.CursorLeft = buffer;
                        }
                    }
                }
                catch (Exception error)
                {
                    Console.Write("\nServer error: ");
                    Console.WriteLine(error.Message + "\n");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
