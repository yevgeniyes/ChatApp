using NFX;
using NFX.Environment;
using System;
using System.Linq;
using System.Threading;
using ChatApp.Client.ClientServices;
using ChatApp.Contracts;

namespace ChatApp.Client
{
    class ClientChatProcessor
    {
        [Config("$test-service-node")]
        private string m_ChatServiceNode;

        public ClientChatProcessor()
        {
            Console.WriteLine(UIMessages.CHAT_HEADER);
            Console.Write("Logged in as '" + ClientContext._clientName + "'" + Environment.NewLine);
            Console.WriteLine();
            if (ClientContext._clientChatSession.Any<Message>())
            {
                for (int i = 0; i < ClientContext._clientChatSession.Count; i++)
                {
                    Message message = ClientContext._clientChatSession[i];
                    var name = message.name;
                    var time = message.time.ToShortTimeString();
                    var content = message.content;
                    Console.WriteLine(name + ": " + content + " (" + time + ")");
                }
            }
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }


        public void StartChat()
        {
            MessageRequestProcessor backgrounRequst = new MessageRequestProcessor();
            Thread backgroundThread = new Thread(backgrounRequst.Start);
            backgroundThread.Start();

            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                string message = inputProc.ReadMessageInput();
                if (message == null) continue;

                try
                {
                    using (var client = new ChatServiceClient(m_ChatServiceNode))
                    {
                        if (!client.PutMessage(ClientContext._token, message))
                        {
                            Console.WriteLine(UIMessages.SESSION_LOST);
                            backgroundThread.Abort();
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
