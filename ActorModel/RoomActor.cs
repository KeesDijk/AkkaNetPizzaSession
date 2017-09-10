using ActorModel.Messages.Commands;
using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;

namespace ActorModel
{
    public class RoomActor :ReceiveActor
    {
        private readonly ILoggingAdapter _logging = Context.GetLogger();

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

        public override void AroundPreStart()
        {
            _logging.Info("AroundPreStart");
            base.AroundPreStart();
        }

        protected override void PreStart()
        {
            _logging.Info("PreStart");
            base.PreStart();
        }

        public override void AroundPostRestart(Exception cause, object message)
        {
            _logging.Info("AroundPostRestart");
            base.AroundPostRestart(cause, message);
        }

        protected override void PreRestart(Exception reason, object message)
        {
            _logging.Info("PreRestart");
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            _logging.Info("PostRestart");
            base.PostRestart(reason);
        }

        public override void AroundPostStop()
        {
            _logging.Info("AroundPostStop");
            base.AroundPostStop();
        }

        protected override void PostStop()
        {
            _logging.Info("PostStop");
            base.PostStop();
        }
    }
}