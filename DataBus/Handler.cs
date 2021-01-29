using System;
using System.Reflection;

namespace DataBus
{
    public partial class BusBase
    {
        private class Handler
        {
            public readonly object Instant;
            public readonly Type MessageType;
            private readonly MethodInfo _handler;
             
            public Handler() { }
            public Handler(object instant,MethodInfo method)
            {
                Instant = instant;
                _handler = method;
                MessageType = method.GetParameters()[0].ParameterType;
                
            }

            public IResult<object> Handle(IMessage message)
            {
                if (!MessageType.IsInstanceOfType(message))
                { throw new ArgumentException(nameof(message), "The argument is not a vaild message"); }
                object[] input = new object[] { message };
                return (IResult<object>)_handler.Invoke(Instant, input);
            }

        }
    }

    
}
