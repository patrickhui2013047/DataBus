using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBus
{
    public interface IBus
    {
        /// <summary>
        /// Searches the subscribed handlers to check if we have a handler for
        /// the message type supplied.
        /// </summary>
        /// <param name="messageType">The message type to check with</param>
        /// <returns>True if any handler is found, false if not.</returns>
        bool HandlerExistsFor(Type messageType);

        /// <summary>
        /// Subscribes an instance to all events declared through implementations of <see cref = "IHandle{T}" />
        /// </summary>
        /// <param name = "subscriber">The instance to subscribe for event publication.</param>
        /// <param name = "marshal">Allows the subscriber to provide a custom thread marshaller for the message subscription.</param>
        /// <returns>The subscriber ID</returns>
        int Subscribe(IBusMember subscriber);

        /// <summary>
        /// Unsubscribes the instance from all events.
        /// </summary>
        /// <param name = "subscriber">The instance to unsubscribe.</param>
        void Unsubscribe(IBusMember subscriber);

        /// <summary>
        /// Broadcast a message to all subscriber
        /// </summary>
        /// <param name = "message">The message to broadcast.</param>
        void Broadcast(IMessage message);

        /// <summary>
        /// Push a message to a subscriber
        /// </summary>
        /// <param name = "message">The message to broadcast.</param>
        /// <param name="id">The id of subscriber</param>
        IResult<object> Push(IMessage message, int id);
    }
}
