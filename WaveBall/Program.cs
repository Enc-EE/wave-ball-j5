using Grpc.Core;
using System;

namespace WaveBall
{
    class Program
    {
        const int Port = 30051;

        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Waveball.waveball.BindService(new RpcImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
