using Ignition.Repo.Model;

namespace Ignition.Repo.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Ignition.Repo.IgniteDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Ignition.Repo.IgniteDataContext context)
        {
            context.Users.AddOrUpdate(u=>u.Username,new User {Username = "bianca", Password = "bianca", Role = 1});
        }
    }
}
