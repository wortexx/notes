using System;
using Domain.Model;
using Domain.Model.Notes;
using Domain.Model.Services;

namespace Infrastructure.Persistence
{
    public class NoteRepository : INoteRepository
    {
        
        #region Implementation of INoteRepository

        public Note GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Note note)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}