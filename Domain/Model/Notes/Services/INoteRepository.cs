using System;
using Domain.Model.Notes;

namespace Domain.Model.Services
{
    public interface INoteRepository
    {
        Note GetById(Guid id);
        void Save(Note note);
    }
}