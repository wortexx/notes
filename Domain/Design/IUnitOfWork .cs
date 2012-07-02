using System;

namespace Domain.Design
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}