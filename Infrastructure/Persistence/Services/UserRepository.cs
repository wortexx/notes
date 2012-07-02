using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Model.Users;
using Domain.Model.Users.Services;

namespace Infrastructure.Persistence.Services
{
    public class UserRepository : IUserRepository
    {
        private NotesContext _dbContext;

        public UserRepository()
        {
            _dbContext = new NotesContext();
        }
        #region Implementation of IRepository<User>

        public void Save(User aggregate)
        {
            _dbContext.Users.Add(aggregate);
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.Single(x => x.Id == id);
        }

        public User FindBy(Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Users.Single(predicate);
        }

        #endregion
    }
}