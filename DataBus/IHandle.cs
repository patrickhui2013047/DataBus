using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBus
{
    /// <summary>
    /// Denotes a class which can handle a particular type of message.
    /// </summary>
    // <typeparam name = "IMessage">The type of message to handle.</typeparam>
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IHandle<IMessage>
    {
        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name = "message">The message.</param>
        
        /// <returns>A task that represents the asynchronous coroutine.</returns>
        IResult<object> Handle(IMessage message);

        
    }
}
