using Ignition.Repo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignition.Repo
{
    public class igniteDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public igniteDataContext() : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            //return ConfigurationManager.ConnectionStrings["eRecruitment"].ConnectionString;
            return @"Data Source=FLORIN-PC\SQLEXPRESS;Initial Catalog=ignite;Integrated Security=true;";
        }
    }

}
