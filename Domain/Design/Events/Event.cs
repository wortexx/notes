using System;

namespace Domain.Design.Events
{
    public class Event : IMessage
    {
        public DateTime Timestamp;
        
        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}