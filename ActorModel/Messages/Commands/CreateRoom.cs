using System;

namespace ActorModel.Messages.Commands
{
    public class CreateRoom
    {
        public CreateRoom(Guid id, string subject)
        {
            Subject = subject;
            Id = id;
        }

        public Guid Id { get; private set; } 
        public string Subject { get; private set; }
    }
}