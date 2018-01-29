using Microsoft.EntityFrameworkCore;
using SARC.Data.Entities;

namespace SARC.Repository
{
    public class ApplicationContext : DbContext  
    {  
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)  
        {  
        }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            base.OnModelCreating(modelBuilder);  
            //new UserMap(modelBuilder.Entity<User>());  
        }

        public DbSet<User> Users { get; set; }
    } 
}
