using System;

namespace ActorModel.Messages.Commands
{
    public class CreateUser
    {
        public CreateUser(string name)
        {
            Name = name;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}