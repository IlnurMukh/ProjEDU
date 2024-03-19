using System.Data.Entity;

namespace ProjEDU.Model
{
    public class ContentContext : DbContext
    {
        //public ContentContext() : base("Data Source=HOME-PC;Initial Catalog=ProjEDU;Persist Security Info = True;Integrated Security=True")
        public ContentContext(): base("Data Source=(LocalDb)\\LocalDB;Initial Catalog=ProjEDU;Persist Security Info = True;Integrated Security=True")
        { }
        public DbSet<Content> Contents { get; set; }

    }
}