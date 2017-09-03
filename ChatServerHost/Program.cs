using ActorModel;
using Akka.Actor;
using Akka.DI.Core;
using Akka.DI.Ninject;
using ChatServerInfraStructure;
using Ninject;
using System;

namespace ChatServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new StandardKernel();
            container.Bind<IWriter>().To<ConsoleWriter>();
            container.Bind<HelloActor>().ToSelf();

            ActorSystem system = ActorSystem.Create("MyChatServer");

            IDependencyResolver resolver = new NinjectDependencyResolver(container, system);

            IActorRef actorRef = system.ActorOf(resolver.Create<HelloActor>());

            actorRef.Tell("Kees");
            actorRef.Tell(11);
            actorRef.Tell(11);
            actorRef.Tell("Kees");

            Console.WriteLine("press any key");
            Console.ReadLine();
            system.Terminate();
           
        }
    }
}
