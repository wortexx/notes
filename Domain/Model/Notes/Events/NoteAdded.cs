using System;
using Ncqrs.Eventing.Sourcing;
using Primitives.Notes;

namespace Domain.Model.Notes.Events
{
    [Serializable]
    public class NoteAdded : SourcedEvent
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public NoteColor Color { get; set; }
        public DateTime CreationDate { get; set; }
    }
}