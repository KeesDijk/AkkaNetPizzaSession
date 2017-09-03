using Akka.Actor;
using ChatServerInfraStructure;

namespace ActorModel
{
    public class HelloActor : ReceiveActor
    {
        private IWriter _writer;
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
            });
            ReceiveAny(msg =>
            {
                _writer.WriteLine("Huh ?");
                Become(NonDefault);
            });
            
        }

        private void NonDefault()
        {
            Receive<string>(msg =>
            {
                _writer.WriteLine("Hello hello: {0}", msg);
                Become(Default);
            });
            ReceiveAny(msg =>
            {
                _writer.WriteLine("Huh huh ?");
                Become(Default);
            });
        }
    }
}
