using GrpcService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrpcService.Data.Configuration
{
    public class GameTransactionConfiguration : IEntityTypeConfiguration<GameTransaction>
    {
        public void Configure(EntityTypeBuilder<GameTransaction> builder)
        {
            builder.ToTable("GameTransactions");
            ConfigureGameTransactionFields(builder);
            ConfigureGameTransactionRelations(builder);
        }

        private void ConfigureGameTransactionFields(EntityTypeBuilder<GameTransaction> builder)
        {
            builder.Property(g => g.Id).HasColumnName("id");
            builder.Property(g => g.SenderUserId).HasColumnName("sender_id");
            builder.Property(g => g.ReseiverUserId).HasColumnName("reseiver_id");
            builder.Property(g => g.Amount).HasColumnName("amount");
            builder.Property(g => g.TransactionDate).HasColumnName("transactio_date");
        }

        private void ConfigureGameTransactionRelations(EntityTypeBuilder<GameTransaction> builder)
        {
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(g => g.SenderUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_GameTransaction_SenderUser");

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(g => g.ReseiverUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_GameTransaction_ReseiverUser");
        }
    }
}
