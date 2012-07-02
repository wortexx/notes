using System;
using Domain.Design;
using Domain.Design.Events;

namespace Domain.Model.Users
{
    public class User : AggregateRoot
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public User(Guid id, string userName, string email, string firstName = "", string lastName = "") : base(id)
        {
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Id = id;

            Apply(new UserAdded(id, userName, email, firstName, lastName));
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserAdded : Event
    {
        public readonly Guid Id;
        public readonly string UserName;
        public readonly string Email;
        public readonly string FirstName;
        public readonly string LastName;

        public UserAdded(Guid id, string userName, string email, string firstName, string lastName)
        {
            Id = id;
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}