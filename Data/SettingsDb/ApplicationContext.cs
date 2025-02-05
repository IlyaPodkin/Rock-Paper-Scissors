using GrpcService.Models;
using Microsoft.EntityFrameworkCore;
using GrpcService.Data.Configuration;

namespace GrpcService.Data.SettingsDb
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<GameTransaction> GameTransactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MatchHistory> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GameTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new MatchHistoryConfiguration());
        }
    }
}