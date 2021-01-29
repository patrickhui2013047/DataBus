using System;

namespace DataBus
{
    public partial class BusBase
    {
        private class BusLogger : ILogger
        {
            public IBus Bus { get; }
            public int ID => throw new NotImplementedException();
            public void Log(IMessage message)
            {
                Handle(message);
            }
            public IResult<object> Handle(IMessage message)
            {
                Console.WriteLine("Logger logged message send into bus, from ID[{0}] to ID[{1}]: {2}",message.SenderID,message.ReceiverID,message.ToString());
                return ResultBase.NullResult(message);
            }
        }
    }

    
}
