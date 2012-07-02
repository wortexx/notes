using System;

namespace Domain.Design
{
    public interface IRepository<T> where T : AggregateRoot//, new()
    {
        void Save(T aggregate);
        T GetById(Guid id);
    }
}