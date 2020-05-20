using BaseApiEfDocker.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseApiEfDocker.Context
{
    public class MSSQLContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }

        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(p =>
            {
                p.ToTable("Pessoa");

                p.HasKey(k => k.id);
            });
        }
    }
}