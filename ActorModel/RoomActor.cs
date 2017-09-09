using Akka.Actor;
using System;
using System.Collections.Generic;

namespace ActorModel
{
    public class RoomActor :ReceiveActor
    {
        private string _subject;
        private Guid _id;

        private List<Guid> _users = new List<Guid>();
        public RoomActor(string subject, Guid id)
        {
            _subject = subject;
            _id = id;
        }
    }
}