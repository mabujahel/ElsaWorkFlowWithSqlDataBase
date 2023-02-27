using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ElsaWorkFlowWithSqlDataBase.Models
{

    

    public class ElsaDbContext : DbContext
    {
        public ElsaDbContext(DbContextOptions<ElsaDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-6GJKG8CK;Database=ElsaDb; Trusted_Connection=True;");
        }

        public DbSet<DocumentApproval> DocumentApprovals { get; set; }

    }


    public class BloggingContextFactory : IDesignTimeDbContextFactory<ElsaDbContext>
    {
        public ElsaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ElsaDbContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-6GJKG8CK;Database=ElsaDb; Trusted_Connection=True;");

            return new ElsaDbContext(optionsBuilder.Options);
        }
    }


}
