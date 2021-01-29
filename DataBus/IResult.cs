using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBus
{
    /// <summary>
    /// Denotes a class which hold the resopnd of message.
    /// </summary>
    // <typeparam name = "IMessage">The type of message to handle.</typeparam>

    public interface IResult<IMessage>
    {
        /// <summary>
        /// Raw result of message
        /// </summary>
        object Result { get; set; }

        /// <summary>
        /// The result is null or not
        /// </summary>
        bool IsNull { get; set; }

        /// <summary>
        /// The message that passed
        /// </summary>
        IMessage Message { get; }
    }
}
