using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Repositories.Config;
using System.Reflection;
using System.Linq;

namespace Repositories
{
    public class RepositoryContext :IdentityDbContext<IdentityUser>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Talk> Talks {get; set;}

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config dosyalarımızı kullanabilmek için
            base.OnModelCreating(modelBuilder);
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    
        }

    }
}
