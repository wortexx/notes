using System;
using Domain.Model.Notes;
using Domain.Model.Services;

namespace Infrastructure.Persistence
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesContext _dbContext;

        public NoteRepository(NotesContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Implementation of INoteRepository

        public Note GetById(Guid id)
        {
            return _dbContext.Notes.Find(id);
        }

        public void Save(Note note)
        {
            _dbContext.Notes.Add(note);
        }

        #endregion
    }
}