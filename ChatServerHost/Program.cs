using ActorModel;
using ActorModel.Messages;
using ActorModel.Messages.Commands;
using ActorModel.Messages.Requests;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("MyChatServer");

            IActorRef userManeger = system.ActorOf<UserManagerActor>();

            CreateUsers(userManeger);

            var roomManager = system.ActorOf<RoomManagerActor>("RoomManager");

            roomManager.Tell(new CreateRoom(Guid.NewGuid(), "Subject1"));
            //roomManager.Tell(new CreateRoom(Guid.NewGuid(), "Subject2"));

            Task<AllRooms> task = roomManager.Ask<AllRooms>(new ListAllRooms());

            AllRooms taskResult = task.Result;

            Guid roomGuid = Guid.Empty;
            foreach (KeyValuePair<Guid, string> room in taskResult.Rooms)
            {
                Console.WriteLine("{0}:{1}",room.Key,room.Value);
                roomGuid = room.Key;
            }

            roomManager.Tell(new JoinRoom(Guid.NewGuid(), roomGuid));
            roomManager.Tell(new JoinRoom(Guid.NewGuid(), roomGuid));
            roomManager.Tell(new JoinRoom(Guid.NewGuid(), roomGuid));
            roomManager.Tell(new JoinRoom(Guid.NewGuid(), roomGuid));


            Console.WriteLine("press any key");
            Console.ReadLine();
            system.Terminate();
           
        }

        private static void CreateUsers(IActorRef actorRef)
        {
            actorRef.Tell(new CreateUser(Guid.NewGuid(), "Kees"));
            actorRef.Tell(new CreateUser(Guid.NewGuid(), "Piet"));
            actorRef.Tell(new CreateUser(Guid.NewGuid(), "Karel"));

            Task<AllUsers> task = actorRef.Ask<AllUsers>(new ListAllUsers());

            AllUsers taskResult = task.Result;

            foreach (var user in taskResult.Users)
            {
                Console.WriteLine(user.Value);
            }
        }
    }
}
