# DataBus

## Descripion
DataBus is a small custom libary to creat data transmittion bus between different instants.
Bus is the backbone of the data transmittion you are recommanded to create it in the class of Main function.


### Structure
 - Bus			Data bus. [IBus] is use for customizing you bus, a [BusBase] is provided for instant use and customization
 - BusMember	Member of bus, only bus member is subscribe to the bus. [IBusMember] is provided to change your class into a bus member.
 - Handle		Handler of message. [IHandle] is use to select what kind of message to receive. To receive a message named with [MessageTypeA], you should inheribit the [IHandle<MessageTypeA>].
 - Result		The processced result of message. [IResult] is provided to customize your result and a[ResultBase] is provided for som common result.
 - Message		The body of data. [IMessage] is provided to create your message class
 - Logger		Data bus logger. [ILogger] is provided for create your logger or attach to external logger.

 A simple project for understanding 
