using System;

namespace ActorModel.Messages.Commands
{
    public class CreateRoom
    {
        public CreateRoom(string subject)
        {
            Subject = subject;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Subject { get; private set; }
    }
}