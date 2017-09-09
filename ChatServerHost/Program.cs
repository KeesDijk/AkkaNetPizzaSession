using ActorModel;
using ActorModel.Messages;
using ActorModel.Messages.Commands;
using ActorModel.Messages.Requests;
using Akka.Actor;
using Akka.DI.Core;
using Akka.DI.Ninject;
using ChatServerInfraStructure;
using Ninject;
using System;
using System.Threading.Tasks;

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

            IActorRef actorRef = system.ActorOf(resolver.Create<UserManagerActor>());

            actorRef.Tell(new CreateUser("Kees"));
            actorRef.Tell(new CreateUser("Piet"));
            actorRef.Tell(new CreateUser("Karel"));

            Task<AllUsers> task = actorRef.Ask<AllUsers>(new ListAllUsers());

            AllUsers taskResult = task.Result;
                    
            foreach (var user in taskResult.Users)
            {
                Console.WriteLine(user.Value);
            }

            Console.WriteLine("press any key");
            Console.ReadLine();
            system.Terminate();
           
        }
    }
}
