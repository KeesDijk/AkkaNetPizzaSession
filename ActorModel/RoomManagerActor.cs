using ActorModel.Messages;
using ActorModel.Messages.Commands;
using ActorModel.Messages.Requests;
using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using Room = System.Tuple<string, Akka.Actor.IActorRef>;

namespace ActorModel
{
    public class RoomManagerActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logging = Context.GetLogger();
        private readonly Dictionary<Guid, Room> _rooms = new Dictionary<Guid, Room>();

        public RoomManagerActor()
        {
            Receive<CreateRoom>(msg =>
            {
                if (!_rooms.ContainsKey(msg.Id))
                {
                    var actorRef = Context.ActorOf(Props.Create<RoomActor>(msg.Subject, msg.Id));
                    _rooms[msg.Id] = new Room(msg.Subject, actorRef);
                    _logging.Info("Room created, subject: {0}", msg.Subject);
                }
                else
                {
                    _logging.Info("Room NOT created, room key allready existed: {0}", msg.Id);
                }
            });

            Receive<ListAllRooms>(msg =>
            {
                Context.Sender.Tell(new AllRooms(_rooms.ToDictionary(
                    kv => kv.Key, 
                    kv => kv.Value.Item1
                )));
            });

            Receive<JoinRoom>(msg =>
            {
                _rooms[msg.Room].Item2.Forward(msg);
            });
        }
    }
}