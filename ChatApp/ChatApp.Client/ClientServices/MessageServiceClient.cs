using System;
using NFX.Glue;
using NFX.Glue.Protocol;
using ChatApp.Contracts.Services;
using System.Collections.Generic;

namespace ChatApp.Client.ClientServices
{
    class MessageServiceClient : ClientEndPoint, IMessageRequestService
    {
        private static TypeSpec s_ts_CONTRACT;
        private static MethodSpec s_ms_RequestMessages_0;

        static MessageServiceClient()
        {
            var t = typeof(IMessageRequestService);
            s_ts_CONTRACT = new TypeSpec(t);
            s_ms_RequestMessages_0 = new MethodSpec(t.GetMethod("RequestMessages", new Type[] { typeof(string) }));
        }

        public MessageServiceClient(string node, Binding binding = null) : base(node, binding) { ctor(); }
        public MessageServiceClient(Node node, Binding binding = null) : base(node, binding) { ctor(); }
        public MessageServiceClient(IGlue glue, string node, Binding binding = null) : base(glue, node, binding) { ctor(); }
        public MessageServiceClient(IGlue glue, Node node, Binding binding = null) : base(glue, node, binding) { ctor(); }

        private void ctor()
        {

        }

        public override Type Contract
        {
            get { return typeof(IMessageRequestService); }
        }

        public List<string> RequestMessages(string lastMessage)
        {
            var call = Async_RequestMessages(lastMessage);
            return call.GetValue<List<string>>();
        }

        public CallSlot Async_RequestMessages(string lastMessage)
        {
            var request = new RequestAnyMsg(s_ts_CONTRACT, s_ms_RequestMessages_0, false, RemoteInstance, new object[] { lastMessage });
            return DispatchCall(request);
        }
    }
}
