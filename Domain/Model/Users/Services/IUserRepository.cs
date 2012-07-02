using System;
using System.Linq.Expressions;
using Domain.Design;

namespace Domain.Model.Users.Services
{
    public interface IUserRepository : IRepository<User>
    {
        User FindBy(Expression<Func<User, bool>> predicate);
    }
}