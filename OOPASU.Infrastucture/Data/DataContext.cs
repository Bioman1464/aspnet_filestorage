using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOPASU.Domain;

namespace OOPASU.Api.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new TodoEntityTypeConfiguration().Configure(modelBuilder.Entity<Todo>());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<DataEventRecord> DataEventRecord { get; set; }
        
        public DbSet<FileModel> Files { get; set; }
    }
}