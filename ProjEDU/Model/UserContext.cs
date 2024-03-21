using System.Data.Entity;

namespace ProjEDU.Model
{
    public class UserContext : DbContext
    {
        //public UserContext() : base("Data Source=HOME-PC;Initial Catalog=ProjEDU;Persist Security Info = True;Integrated Security=True")
        public UserContext() : base("Data Source=(LocalDb)\\LocalDB;Initial Catalog=ProjEDU;Persist Security Info = True;Integrated Security=True")

        { }
        public DbSet<User> Users { get; set; }

    }
}
