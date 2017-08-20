using Akka.Actor;
using System;

namespace ActorModel
{
    public class HelloActor : ReceiveActor
    {
        public HelloActor()
        {
            Become(Default);
        }

        private void Default()
        {
            Receive<string>(msg =>
            {
                Console.WriteLine("Hello: {0}", msg);
                Become(NonDefault);
            });
            ReceiveAny(msg =>
            {
                Console.WriteLine("Huh ?");
                Become(NonDefault);
            });
            
        }

        private void NonDefault()
        {
            Receive<string>(msg =>
            {
                Console.WriteLine("Hello hello: {0}", msg);
                Become(Default);
            });
            ReceiveAny(msg =>
            {
                Console.WriteLine("Huh huh ?");
                Become(Default);
            });
        }
    }
}
