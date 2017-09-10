using ActorModel.Messages.Commands;
using Akka.Actor;
using System;
using System.Collections.Generic;

namespace ActorModel
{
    public class RoomActor :ReceiveActor
    {
        private string _subject;
        private Guid _id;
        private readonly List<Guid> _users = new List<Guid>();

        public RoomActor(string subject, Guid id)
        {
            _subject = subject;
            _id = id;

            Receive<JoinRoom>(msg =>
            {
                if (msg.Room.Equals(_id) && !_users.Contains(msg.User))
                {
                    _users.Add(msg.User);
                }
            });
        }
    }
}