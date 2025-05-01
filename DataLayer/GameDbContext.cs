using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using System.Drawing;
namespace DataLayer
{
    public class GameDbContext : DbContext
    {
        public GameDbContext() : base()
        {
            
        }

        public GameDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=DESKTOP-U242LRB\\SQLEXPRESS;Database=TerraMars;Trusted_Connection=true;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Tile> Tiles { get; set; }
        public DbSet<Structure> Structures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Color конвертиране (ARGB -> int)
            modelBuilder.Entity<Tile>()
                .Property(t => t.Color)
                .HasConversion(
                    c => c.ToArgb(),
                    argb => Color.FromArgb(argb)
                );

            // Връзка: User -> Maps
            modelBuilder.Entity<Map>()
                .HasOne(m => m.Owner)
                .WithMany(u => u.Maps)
                .HasForeignKey(m => m.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Връзка: Map -> Tiles
            modelBuilder.Entity<Tile>()
                .HasOne(t => t.Map)
                .WithMany(m => m.Tiles)
                .HasForeignKey(t => t.MapId)
                .OnDelete(DeleteBehavior.Cascade);

            // Връзка: Map -> Structures
            modelBuilder.Entity<Structure>()
                .HasOne(s => s.Map)
                .WithMany(m => m.Structures)
                .HasForeignKey(s => s.MapId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
