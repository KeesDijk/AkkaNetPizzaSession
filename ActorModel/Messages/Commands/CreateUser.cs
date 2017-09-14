using System;

namespace ActorModel.Messages.Commands
{
    public class CreateUser
    {
        public CreateUser(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}