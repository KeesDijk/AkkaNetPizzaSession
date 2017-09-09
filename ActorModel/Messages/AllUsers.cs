using System;
using System.Collections.Generic;

namespace ActorModel.Messages
{
    public class AllUsers
    {
        public AllUsers(Dictionary<Guid, string> users)
        {
            Users = users;
        }

        public Dictionary<Guid, string> Users { get; private set; }
    }
}