using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBus
{
    public interface IBusMember
    {
         IBus Bus { get; }
        int ID { get;}
    }
}
