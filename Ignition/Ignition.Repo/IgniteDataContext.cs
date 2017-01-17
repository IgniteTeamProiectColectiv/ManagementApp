using Ignition.Repo.Model;
using System.Data.Entity;
using System.Configuration;

namespace Ignition.Repo
{
    public class IgniteDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Flux> Fluxs { get; set; }

        public IgniteDataContext() : base(ConfigurationManager.ConnectionStrings["ignite"].ConnectionString)
        {
        }
    }

}
