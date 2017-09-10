using Akka.Actor;
using System;

namespace RemoteChatServerHost
{
    class Program
    {
        static void Main(string[] args)
        {

            var system = ActorSystem.Create("MyChatServer");

            Console.WriteLine("press any key");
            Console.ReadLine();
            system.Terminate();
        }
    }
}
