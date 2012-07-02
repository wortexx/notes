using System;
using Domain.Model.Notes;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Primitives.Notes;

namespace Domain.Commands.Notes
{
    [MapsToAggregateRootConstructor(typeof(Note))]
    public class CreateNote : CommandBase
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public NoteColor Color { get; set; }
    }
}