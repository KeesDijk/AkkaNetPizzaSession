using Akka.Actor;
using Akka.TestKit.Xunit2;
using ChatServerInfraStructure;
using Moq;
using Xunit;

namespace ActorModel.Tests
{
    public class HelloActorTests : TestKit
    {
        [Fact]
        public void ShouldBeAbleToStartHelloActor()
        {
            //Arrange
            var mockWriter = new Mock<IWriter>();
            
            var actor = ActorOfAsTestActorRef<HelloActor>(Props.Create(() => new HelloActor(mockWriter.Object)));

            //Act
            actor.Tell("Hallo");

            //Assert
            mockWriter.Verify(_ => _.WriteLine(It.IsAny<string>(), It.IsAny<object[]>()),Times.Once);
        }
    }
}
