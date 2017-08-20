using Akka.Actor;
using System;

namespace ActorModel
{
    public class HelloActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            var msg = message as string;
            if (msg != null)
            {
                Console.WriteLine("Hello: {0}", msg);
            }
            else
            {
                Console.WriteLine("Huh ?");
            }
        }
    }
}
