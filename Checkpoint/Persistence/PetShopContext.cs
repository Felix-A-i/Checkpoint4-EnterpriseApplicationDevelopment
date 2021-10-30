using Checkpoint.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.Persistence
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions options) : base(options){}

        public DbSet<Gato> Gatos { get; set; }
        public DbSet<Cachorro> Cachorros { get; set; }
        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amigo>().HasKey(a => new { a.CachorroId, a.GatoId });

            modelBuilder.Entity<Amigo>()
                .HasOne(a => a.Cachorro)
                .WithMany(a => a.Amigos)
                .HasForeignKey(a => a.CachorroId);

            modelBuilder.Entity<Amigo>().
                HasOne(a => a.Gato)
                .WithMany(a => a.Amigos)
                .HasForeignKey(a => a.GatoId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
