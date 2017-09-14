using Akka.Actor;

namespace ActorModel.ExternalSystem
{
    public class ExternalSystemBridgeActor : ReceiveActor
    {
        private readonly IEventPusher _eventPusher;
        private readonly IActorRef _roomManager;
        private readonly IActorRef _userManager;

        public ExternalSystemBridgeActor(IEventPusher eventPusher, IActorRef roomManager, IActorRef userManager)
        {
            _eventPusher = eventPusher;
            _roomManager = roomManager;
            _userManager = userManager;
        }
    }
}