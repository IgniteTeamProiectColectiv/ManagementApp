using Ignition.Repo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Ignition.Repo
{
    public class igniteDataContext : DbContext
    {
        private static string connectionString = ConfigurationSettings.AppSettings["connectionString"];

        //add the following lines in your App.config before </configuration>
        // <appSettings>
        //   <add key="Connection String" value="connectionString=Data Source =DESKTOP-3JU4JU4; Initial Catalog = ignite; Integrated Security = TRUE;"/>
        // </appSettings>

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Flux> Fluxs { get; set; }

        public igniteDataContext() : base(GetConnectionString())
        {

        }
        public static string GetConnectionString()
        {
            return connectionString;
        }
    }

}
