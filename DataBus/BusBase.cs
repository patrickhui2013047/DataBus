using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBus
{
    /// <summary>
    /// A base class of bus
    /// </summary>
    public partial class BusBase : IBus
    {
        private readonly List<Handler> handlers = new List<Handler>();
        private readonly List<IBusMember> busMembers = new List<IBusMember>();
        private readonly ILogger logger = new BusLogger();
        private bool LogPushMessage,WithLogger;

        public BusBase(bool withLogger = true, bool logPushMessage = true)
        {
            WithLogger = withLogger;
            if (WithLogger)
            {
                this.Subscribe(logger);
            }
            LogPushMessage = logPushMessage;
        }
        public void Broadcast(IMessage message)
        {
            var messageType = message.GetType();
            var targetList = handlers.FindAll(obj => obj.MessageType == messageType);
            if (WithLogger)
            {
                Log(message);
            }
            foreach (Handler handler in targetList)
            {
                handler.Handle(message);
            }
        }
        public bool MessageHandlerExists(IMessage message)
        {
            return handlers.FindAll(obj => obj.MessageType == message.GetType()).Count>0;
            
        }
        public bool HandlerExistsFor(Type busMember)
        {
            var interfaceList=busMember.GetInterfaces();
            return interfaceList.Where(obj => IsIHandle(obj)).Count()>0;
        }

        public IResult<object> Push(IMessage message, int id)
        {
            message.ReceiverID = id;
            return Push(message);
        }
        public IResult<object> Push(IMessage message)
        {
            if (!MessageHandlerExists(message))
            {
                throw new NotImplementedException(message.GetType().Name+" have no handler created.");
            }
            if (message.ReceiverID == -1 || (message.ReceiverID >= busMembers.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(message), "The message receiver ID is not vaild");
            }
            var instant = busMembers[message.ReceiverID];
            var messageType = message.GetType();
            var targetList = handlers.FindAll(obj => obj.Instant == instant && obj.MessageType == messageType);
            if (LogPushMessage)
            {
                Log(message);
            }
            return targetList[0].Handle(message);
            
        }

        public void Log(IMessage message)
        {
            logger.Log(message);
        }

        public int Subscribe(IBusMember subscriber)
        {
            if (!HandlerExistsFor(subscriber.GetType()))
            {
                throw new ArgumentException(nameof(subscriber),"The argument have no handler");
            }
            if (handlers.FindAll(obj=> obj.Instant==subscriber).Count>0)
            {
                return subscriber.ID;
            }
            var handerlist = subscriber.GetType().GetMethods().Where(obj=> obj.Name=="Handle").ToList();

            foreach(MethodInfo handler in handerlist)
            {
                handlers.Add(new Handler(subscriber,handler));
            }
            busMembers.Add(subscriber);
            return busMembers.FindIndex(obj=> obj==subscriber);
        }

        public void Unsubscribe(IBusMember subscriber)
        {
            handlers.RemoveAll(obj => obj.Instant == subscriber);
            busMembers.RemoveAll(obj => obj == subscriber);
        }

        private bool IsIHandle(Type type)
        {
            return type.Name.StartsWith("IHandle") && type.Namespace == "DataBus";
        }
    }

    
}
