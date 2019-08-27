using System;
using Grpc.Core;
using Grpc.Reflection;
using Grpc.Reflection.V1Alpha;

namespace ProtoHub
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var reflectionServiceImpl = new ReflectionServiceImpl(ProtoHubService.Descriptor, ServerReflection.Descriptor);
                Server server = new Server
                {
                    Services = {
                        ServerReflection.BindService(reflectionServiceImpl),
                        ProtoHubService.BindService(new ProtoHubImpl())
                    },
                    Ports = { new ServerPort("localhost", 5000, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine("Server listening on port " + 5000);
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();
                server.ShutdownAsync().Wait();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }
    }
}
