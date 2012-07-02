using System.Data.Entity;
using Domain.Model;
using Domain.Model.Notes;
using Domain.Model.Users;

namespace Infrastructure.Persistence
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Design.AggregateRoot>().HasKey(x => x.Id);
            
            modelBuilder.Entity<User>().HasKey(x => x.Id);
        }
    }

    public class UserConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasEntitySetName("User");
            HasKey(x => x.Id);
            HasRequired(x => x.Email);
            HasRequired(x => x.FirstName);
            HasRequired(x => x.LastName);
        }
    }
}