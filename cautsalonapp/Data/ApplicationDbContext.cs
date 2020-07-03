using System;
using System.Collections.Generic;
using System.Text;
using cautsalon.Models;
using cautsalonapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cautsalonapp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public ApplicationDbContext()
        {

        }

       

        public DbSet<Firme> Firme { get; set; }
        public DbSet<Clienti> Clienti { get; set; }
        public DbSet<Saloane> Saloane { get; set; }
        public DbSet<Servicii> Servicii { get; set; }
        public DbSet<Programari> Programari { get; set; }
        public DbSet<SaloaneServicii> SaloaneServicii { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "admin", NormalizedName = "admin".ToUpper() });
            modelBuilder.Entity<IdentityRole>()
               .HasData(new IdentityRole { Name = "salonowner", NormalizedName = "salonowner".ToUpper() });
            modelBuilder.Entity<IdentityRole>()
               .HasData(new IdentityRole { Name = "client", NormalizedName = "client".ToUpper() });

            
            modelBuilder.Entity<Firme>()
                        .HasKey(k => k.Cod_firma)
                        .HasName("cod_firma");
            modelBuilder.Entity<Clienti>()
                        .HasKey(k => k.Cod_client)
                        .HasName("cod_client");
            modelBuilder.Entity<Saloane>()
                        .HasKey(k => k.Cod_salon)
                        .HasName("cod_salon");
            modelBuilder.Entity<Servicii>()
                        .HasKey(k => k.Cod_serviciu)
                        .HasName("cod_serviciu");
            modelBuilder.Entity<Programari>()
                        .HasKey(k => k.Cod_programare)
                        .HasName("cod_programare");
            modelBuilder.Entity<SaloaneServicii>()
                        .HasKey(k => k.Id)
                        .HasName("id");
        }
    }
}
