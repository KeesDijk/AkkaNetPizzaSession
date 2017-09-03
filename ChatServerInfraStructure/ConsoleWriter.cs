using System;

namespace ChatServerInfraStructure
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}
