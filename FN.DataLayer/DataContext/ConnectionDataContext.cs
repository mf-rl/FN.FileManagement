using Microsoft.EntityFrameworkCore;
using FN.DataLayer.Contract.Tables;

namespace FN.DataLayer.DataContext
{
    public class ConnectionDataContext : DbContext
    {
        public ConnectionDataContext(DbContextOptions<ConnectionDataContext> options) : base(options)
        {            
        }
        public DbSet<Upload> Uploads { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Upload>().ToTable("Upload");
        }
    }
}
