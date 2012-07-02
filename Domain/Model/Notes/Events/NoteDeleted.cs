using System;
using Ncqrs.Eventing.Sourcing;

namespace Domain.Model.Notes.Events
{
     [Serializable]
    public class NoteDeleted : SourcedEvent
    {
        
    }
}