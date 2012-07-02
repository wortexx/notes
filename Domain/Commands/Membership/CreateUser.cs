using Domain.Design.Commands;

namespace Domain.Commands.Membership
{
    public class CreateUser : Command
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}