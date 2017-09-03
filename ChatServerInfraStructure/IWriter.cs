namespace ChatServerInfraStructure
{
    public interface IWriter
    {
        void WriteLine(string message, params object[] args);
    }
}