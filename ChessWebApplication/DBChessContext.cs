using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ChessWebApplication
{
    public partial class DBChessContext : DbContext
    {
        public DBChessContext()
        {

        }

        public DBChessContext(DbContextOptions<DBChessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Debut> Debuts { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Move> Moves { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server= DESKTOP-9JSCHV0; Database=DBChess; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Debut>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.Result1)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Result2)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Debut)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.DebutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Debuts");

                entity.HasOne(d => d.PlayerId1Navigation)
                    .WithMany(p => p.MatchPlayerId1Navigations)
                    .HasForeignKey(d => d.PlayerId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Players");

                entity.HasOne(d => d.PlayerId2Navigation)
                    .WithMany(p => p.MatchPlayerId2Navigations)
                    .HasForeignKey(d => d.PlayerId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Players1");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Tournaments");
            });

            modelBuilder.Entity<Move>(entity =>
            {
                entity.Property(e => e.Move1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Move");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Moves_Matches");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Counrty)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CounrtyId)
                    .HasConstraintName("FK_Players_Countries");
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.WinnerNavigation)
                    .WithMany(p => p.Tournaments)
                    .HasForeignKey(d => d.Winner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tournaments_Players");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
