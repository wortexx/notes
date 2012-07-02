using System;
using System.Transactions;
using Domain.Design;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private NotesContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new NotesContext();
            _transaction = new TransactionScope();
        }
        #region Implementation of IDisposable

        public void Dispose()
        {
            _transaction.Dispose();
        }

        #endregion

        #region Implementation of IUnitOfWork

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
                _transaction.Complete();
            }
            catch (Exception)
            {
                Rollback();
            }
            
        }

        public void Rollback()
        {
            
        }

        #endregion
    }
}