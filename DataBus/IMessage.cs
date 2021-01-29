using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBus
{
    public interface IMessage
    {
        /// <summary>
        /// ID of the bus member to send, -1 mean result not required
        /// </summary>
        int SenderID { get; }

        /// <summary>
        /// ID of the bus member to receive, -1 mean for all, i.e. broadcast
        /// </summary>
        int ReceiverID { get; set; }
    }
}
