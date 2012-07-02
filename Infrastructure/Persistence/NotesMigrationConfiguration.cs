namespace Infrastructure.Persistence
{
    public class NotesMigrationConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<NotesContext>
    {
        public NotesMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}