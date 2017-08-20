using Akka.Actor;
using System;

namespace ActorModel
{
    public class HelloActor : ReceiveActor
    {
        public HelloActor()
        {
            Receive<string>(msg => HandleString(msg));
            ReceiveAny(msg => HandleAny());
        }

        private void HandleAny()
        {
            Console.WriteLine("Huh ?");
        }

        private void HandleString(string msg)
        {
            Console.WriteLine("Hello: {0}", msg);
        }
    }
}
