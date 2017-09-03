using Akka.Actor;
using Akka.Event;
using ChatServerInfraStructure;

namespace ActorModel
{
    public class HelloActor : ReceiveActor
    {
        private readonly IWriter _writer;
        private readonly ILoggingAdapter _logging = Context.GetLogger();

        public HelloActor(IWriter writer)
        {
            _writer = writer;
            Become(Default);
        }

        private void Default()
        {
            Receive<string>(msg =>
            {
                _writer.WriteLine("Hello: {0}", msg);
                Become(NonDefault);
                _logging.Info("Became nonDefault");
            });
            ReceiveAny(msg =>
            {
                _writer.WriteLine("Huh ?");
                Become(NonDefault);
                _logging.Info("Became nonDefault");
            });
            
        }

        private void NonDefault()
        {
            Receive<string>(msg =>
            {
                _writer.WriteLine("Hello hello: {0}", msg);
                Become(Default);
                _logging.Info("Became Default");
            });
            ReceiveAny(msg =>
            {
                _writer.WriteLine("Huh huh ?");
                Become(Default);
                _logging.Info("Became nonDefault");
            });
        }
    }
}
