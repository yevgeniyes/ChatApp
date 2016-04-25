﻿using NFX;
using NFX.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ChatApp.Client.ClientServices;

namespace ChatApp.Client
{
    class ClientChatProcessor : ClientBase
    {
        [Config("$test-service-node")]
        private string m_TestServiceNode;

        public ClientChatProcessor()
        {
            Console.WriteLine(Messages.CHAT_HEADER);
            Console.Write(_clientName + ": ");
            ConfigAttribute.Apply(this, App.ConfigRoot);
        }


        public void StartChat(Guid token)
        {
            MessageRequestProcessor backgrounRequst = new MessageRequestProcessor();
            Thread backgroundThread = new Thread(backgrounRequst.Start);
            backgroundThread.Start();

            while (true)
            {
                ClientInputProcessor inputProc = new ClientInputProcessor();
                string message = inputProc.ReadMessageInput(_clientName);
                if (message == null) continue;

                try
                {
                    using (var client = new ChatServiceClient(m_TestServiceNode))
                    {
                        if (!client.PutMessage(token, message))
                        {
                            Console.WriteLine(Messages.SESSION_LOST);
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
