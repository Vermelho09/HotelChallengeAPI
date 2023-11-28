using DBFirst.Sample.Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alten.HotelChallenge.SQLServer.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> entity)
        {

            entity.ToTable("ROOM");

            entity.HasIndex(e => e.Number, "IX_ROOM_NUMBER").IsUnique();

            entity.HasIndex(e => e.IsActive, "IX_IS_ACTIVE");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");

            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

            entity.Property(e => e.Number)
                .HasColumnName("NUMBER");
        }
    }
}
