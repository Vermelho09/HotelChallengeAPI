using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBFirst.Sample.Project.Models
{
    public partial class AltenContext : DbContext
    {
        private readonly string AltenDBConnectionString;

        public AltenContext(IConfiguration configuration)
        {
            AltenDBConnectionString = configuration.GetConnectionString("SqlConnectionString");
        }

        public AltenContext(DbContextOptions<AltenContext> options, IConfiguration configuration)
            : base(options)
        {
            AltenDBConnectionString = configuration.GetConnectionString("SqlConnectionString");
        }

        public virtual DbSet<Reservation> Reservation { get; set; } = null!;
        public virtual DbSet<Room> Room { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AltenDBConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AltenContext).Assembly);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
