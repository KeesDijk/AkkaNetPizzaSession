using System;
using System.Collections.Generic;

namespace ActorModel.Messages
{
    public class AllRooms
    {
        public AllRooms(Dictionary<Guid, string> rooms)
        {
            Rooms = rooms;
        }

        public Dictionary<Guid, string> Rooms { get; private set; }
    }
}