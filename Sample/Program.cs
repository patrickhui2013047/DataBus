using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBus;

namespace Test
{
    class Program
    {
        //private readonly BusBase bus;
        static void Main(string[] args)
        {
            BusBase bus = new BusBase();
            var sub1 = new Subscriber(bus);
            var sub2 = new Subscriber(bus);
            bus.Push(new Message(sub1, sub2));
            bus.Broadcast(new Message());
        }
    }





    class Subscriber : IBusMember, IHandle<Message>
    {
        public IBus Bus { get; }
        public int ID { get; private set; }
        public Subscriber(IBus bus)
        {
            ID = bus.Subscribe(this);
        }
        public IResult<object> Handle(Message message)
        {
            Console.WriteLine("Subscriber[{0}] receives message from bus member[{1}]: {2}", ID, message.SenderID, message.ToString());
            return ResultBase.NullResult(this);
        }

    }

    class Message : IMessage
    {
        public int SenderID { get; }
        public int ReceiverID { get; set; }

        public Message() { }

        public Message(IBusMember sender, IBusMember receiver)
        {
            SenderID = sender.ID;
            ReceiverID = receiver.ID;
        }
        public Message(IBusMember sender, int receiverID)
        {
            SenderID = sender.ID;
            ReceiverID = receiverID;
        }
    }
}
