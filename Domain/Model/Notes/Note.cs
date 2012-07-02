using System;
using Domain.Model.Notes.Events;
using Ncqrs;
using Ncqrs.Domain;
using Primitives.Notes;

namespace Domain.Model.Notes
{
    public class Note : AggregateRootMappedWithAttributes
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public NoteColor Color { get; set; }

        public bool Deleted { get; protected internal set; }

        public Note(Guid id, string title, string text, NoteColor color = NoteColor.Yellow) : base(id)
        {
            var clock = NcqrsEnvironment.Get<IClock>();

            Title = title;
            Text = text;
            Color = color;
            
            ApplyEvent(new NoteAdded
                           {
                               NoteId = id,
                               Title = title,
                               Text = text,
                               CreationDate = clock.UtcNow()
                           });
        }

        // Event handler for the NewNoteAdded event. This method
        // is automaticly wired as event handler based on convension.
        protected void OnNewNoteAdded(NoteAdded e)
        {
            Title = e.Title;
            Text = e.Text;
            CreationDate = e.CreationDate;
        }

        protected DateTime CreationDate { get; set; }

        public void Delete()
        {
            if (!Deleted)
            {
                Deleted = true;

                ApplyEvent(new NoteDeleted());
            }
        }        
    }
}