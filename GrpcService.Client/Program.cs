using System;

namespace GrpcService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var msg = MsgServiceClient.SayHello("GrpcTestMsg");
                    Console.WriteLine(msg);

                    var msgData = MsgServiceClient.GetOne("5926a4ae87c17fb77ab51975");

                    var list = MsgServiceClient.GetList(0, "1", 0, 0);
                }
                catch (Exception ex)
                {

                }
                Console.ReadKey();
            }
        }
    }
}