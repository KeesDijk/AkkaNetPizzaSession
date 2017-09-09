using ActorModel.Messages.Commands;
using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using ActorModel.Messages;
using ActorModel.Messages.Requests;

namespace ActorModel
{
    public class UserManagerActor : ReceiveActor
    {
        private readonly ILoggingAdapter _logging = Context.GetLogger();
        private readonly Dictionary<Guid, string> users = new Dictionary<Guid, string>();

        public UserManagerActor()
        {
            Receive<CreateUser>(msg =>
            {
                _logging.Info("Creating user: {0}", msg.Id);
                users[msg.Id] = msg.Name;
            });
            Receive<ListAllUsers>((msg) =>
            {
                Context.Sender.Tell(new AllUsers(users));
            });
        }
    }
}