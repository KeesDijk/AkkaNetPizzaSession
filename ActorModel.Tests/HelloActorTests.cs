using Akka.TestKit;
using Akka.TestKit.Xunit2;
using Xunit;

namespace ActorModel.Tests
{
    public class HelloActorTests : TestKit
    {
        [Fact]
        public void ShouldBeAbleToStartHelloActor()
        {
            //Arrange
            TestActorRef<HelloActor> actor = ActorOfAsTestActorRef<HelloActor>();

            //Act
            actor.Tell("Hallo");

            //Assert
        }
    }
}
