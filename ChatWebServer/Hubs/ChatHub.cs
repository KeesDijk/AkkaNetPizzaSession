using Microsoft.AspNet.SignalR;

namespace ChatWebServer.Hubs
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}