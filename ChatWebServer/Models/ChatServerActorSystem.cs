using System;
using ActorModel;
using ActorModel.ExternalSystem;
using ActorModel.Messages.Commands;
using Akka.Actor;

namespace ChatWebServer.Models
{
    public static class ChatServerActorSystem
    {
        public static ActorSystem Actors;
        private static IEventPusher _eventPusher;
        public static void Create()
        {
            Actors = ActorSystem.Create("MyChatServer");

            var userManager = Actors.ActorOf<UserManagerActor>("UserManager");
            var roomManager = Actors.ActorOf<RoomManagerActor>("RoomManager");

            userManager.Tell(new CreateUser(Guid.NewGuid(), "Kees"));
            userManager.Tell(new CreateUser(Guid.NewGuid(), "Piet"));
            userManager.Tell(new CreateUser(Guid.NewGuid(), "Karel"));

            roomManager.Tell(new CreateRoom(Guid.NewGuid(), "Subject1"));
            roomManager.Tell(new CreateRoom(Guid.NewGuid(), "Subject2"));

            UserManager = userManager;
            RoomManager = roomManager;
        }

        public static IActorRef RoomManager { get; set; }

        public static IActorRef UserManager { get; set; }

        public static void Shutdown()
        {
            Actors.Terminate();
        }
    }
}