namespace DataBus
{
    internal interface ILogger:IBusMember,IHandle<IMessage>
    {
        void Log(IMessage message);
    }
}