using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GrpcService.Client
{
    public static class MsgServiceClient
    {
        private static Channel _channel;
        private static MsgService.MsgServiceClient _client;

        static MsgServiceClient()
        {
            var cacert = File.ReadAllText("server.crt");
            var ssl = new SslCredentials(cacert);
            var channOptions = new List<ChannelOption>
            {
                new ChannelOption(ChannelOptions.SslTargetNameOverride,"root"),
            };
            _channel = new Channel("localhost:5001", ssl, channOptions);
            _client = new MsgService.MsgServiceClient(_channel);
        }

        public static GetMsgOneReply GetOne(string Id)
        {
            return _client.GetOne(new GetMsgOneRequest()
            {
                Id= Id
            });
        }

        public static GetMsgListReply GetList(int userId, string title, long startTime, long endTime)
        {
            return _client.GetList(new GetMsgListRequest
            {
                UserId = userId,
                Title = title,
                StartTime = startTime,
                EndTime = endTime
            });
        }

        public static HelloReply SayHello(string name)
        {
            return _client.SayHello(new HelloRequest
            {
                Name=name
            });
        }
    }
}
