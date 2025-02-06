using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GrpcService.Models;
using System.Reflection.Emit;

namespace GrpcService.Data.Configuration
{
    public class MatchHistoryConfiguration : IEntityTypeConfiguration<MatchHistory>
    {
        public void Configure(EntityTypeBuilder<MatchHistory> builder)
        {
            builder.ToTable("MatchHistory");
            ConfigureMatchHistoryFields(builder);
            ConfigureMatchHistoryRelations(builder);
        }

        private void ConfigureMatchHistoryFields(EntityTypeBuilder<MatchHistory> builder)
        {
            builder.Property(h => h.Id).HasColumnName("id");
            builder.Property(h => h.FirstUserId).HasColumnName("first_user_id");
            builder.Property(h => h.SecondUserId).HasColumnName("second_user_id");
            builder.Property(h => h.BetAmount).HasColumnName("bet_amount");
            builder.Property(h => h.WinnerId).HasColumnName("winner_id");
            builder.Property(h => h.MatchDate).HasColumnName("match_date");
            builder.Property(h => h.Status).HasColumnName("status");
        }

        private void ConfigureMatchHistoryRelations(EntityTypeBuilder<MatchHistory> builder)
        {
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(mh => mh.FirstUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MatchHistory_FirstUserId");

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(mh => mh.SecondUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MatchHistory_SecondUserId");

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(mh => mh.WinnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_MatchHistory_WinnerId");
        }
    }
}
