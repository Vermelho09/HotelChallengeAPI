using DBFirst.Sample.Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alten.HotelChallenge.SQLServer.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> entity)
        {

            entity.ToTable("RESERVATION");

            entity.HasIndex(e => e.EndDate, "IX_END_DATE");

            entity.HasIndex(e => e.StartDate, "IX_START_DATE");

            entity.HasIndex(e => e.RoomId, "IX_ROOM_ID");

            entity.HasIndex(e => e.IsConfirmed, "IX_IS_CONFIRMED");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("END_DATE");

            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("START_DATE");

            entity.Property(e => e.IsConfirmed).HasColumnName("IS_CONFIRMED");

            entity.Property(e => e.MainGuestDocument)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MAIN_GUEST_DOCUMENT");

            entity.Property(e => e.MainGuestEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MAIN_GUEST_EMAIL");

            entity.Property(e => e.MainGuestName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAIN_GUEST_NAME");

            entity.Property(e => e.RoomId).HasColumnName("ROOM_ID");

            entity.HasOne(d => d.Room)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_ID");
        }
    }
}
