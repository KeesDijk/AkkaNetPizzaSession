using System;

namespace ActorModel.Messages.Commands
{
    public class JoinRoom
    {
        public JoinRoom(Guid user, Guid room)
        {
            User = user;
            Room = room;
        }

        public Guid User { get; private set; }
        public Guid Room { get; private set; }
    }
}