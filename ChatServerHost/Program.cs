using ActorModel;
using Akka.Actor;
using System;

namespace ChatServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("MyChatServer");
            IActorRef actorRef = system.ActorOf<HelloActor>();

            actorRef.Tell("Kees");
            actorRef.Tell(11);

            Console.WriteLine("press any key");
            Console.ReadLine();
            system.Terminate();
           
        }
    }
}
