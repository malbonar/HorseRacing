
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MBSoftware.HorseRacing.Core.DAL
{
    /// <summary>
    /// Created from an existing database
    /// Microsoft.EntityFrameworkCore
    /// Microsoft.EntityFrameworkCore.Tools
    /// Microsoft.EntityFrameworkCore.SqlServer
    /// Microsoft.EntityFrameworkCore.SqlServer.Design
    /// Opened the nuget Package Manager console:
    /// Scaffold-DbContext "Data Source=conn string;"
    /// parameter prompted - Microsoft.EntityFrameworkcore.SqlServer
    /// </summary>
    public partial class AzureHorseRatingsDbContext : DbContext
    {
        /// <summary>
        /// Manual access via this ctor and OnConfiguring method using connection string from app.config
        /// </summary>
        public AzureHorseRatingsDbContext()
        {
        }

        /// <summary>
        /// Web-API accesses db via this ctor and passes connection string in options
        /// </summary>
        /// <param name="options"></param>
        public AzureHorseRatingsDbContext(DbContextOptions<AzureHorseRatingsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HorseRace> HorseRace { get; set; }
        public virtual DbSet<HorseRaceRunner> HorseRaceRunner { get; set; }
        public virtual DbSet<TrainerJockeyComboFormWebEntities> TrainerJockeyComboFormWebEntities { get; set; }

        /// <summary>
        /// If parameterless ctor is used then this will load the database from app.config file.
        /// This Web-API uses the options to pass in the connection string
        /// </summary>
        /// <param name="optionsBuilder">Options containing the connection string</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["HorseRacingSqlServerConnectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<HorseRace>(entity =>
            {
                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Going)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RaceDate).HasColumnType("datetime");

                entity.Property(e => e.RaceDistance)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RaceName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RaceTime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<HorseRaceRunner>(entity =>
            {
                entity.HasIndex(e => e.HorseRaceWebEntityHorseRaceWebEntityId)
                    .HasName("IX_HorseRaceWebEntity_HorseRaceWebEntityId");

                entity.Property(e => e.ClassForm)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CourseForm)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DirectionForm)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DistanceForm)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GoingForm)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HorseName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HorseRaceWebEntityHorseRaceWebEntityId).HasColumnName("HorseRaceWebEntity_HorseRaceWebEntityId");

                entity.Property(e => e.JockeyHorseSummary)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ormove).HasColumnName("ORMove");

                entity.Property(e => e.Rpr).HasColumnName("RPR");

                entity.Property(e => e.TissueOdds).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TissueTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ts).HasColumnName("TS");

                entity.HasOne(d => d.HorseRaceWebEntityHorseRaceWebEntity)
                    .WithMany(p => p.HorseRaceRunner)
                    .HasForeignKey(d => d.HorseRaceWebEntityHorseRaceWebEntityId)
                    .HasConstraintName("FK_dbo.HorseRaceRunner_dbo.HorseRace_HorseRaceWebEntity_HorseRaceWebEntityId");
            });

            modelBuilder.Entity<TrainerJockeyComboFormWebEntities>(entity =>
            {
                entity.HasKey(e => e.TrainerJockeyComboFormEntityId)
                    .HasName("PK_dbo.TrainerJockeyComboFormWebEntities");

                entity.Property(e => e.Ae)
                    .HasColumnName("AE")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Iv)
                    .HasColumnName("IV")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Jockey)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PlacedPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlacedProfitLoss).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Trainer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WinPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WinProfitLoss).HasColumnType("decimal(18, 2)");
            });
        }
    }
}
