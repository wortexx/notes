using System;
using Domain.Design.Events;

namespace Domain.Design
{
    public class AggregateRoot
    {
        public AggregateRoot(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected internal set; }
        
        public void Apply(Event @event)
        {
            
        }
    }
}