﻿using EfSamurai.Domain;
using EfSamurai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfSamurai.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SamuraiBattle> SamuraiBattles { get; set; }

        public SamuraiContext()
        {

        }

        public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                // Om webappen skapar en SamuraiContext så kommer inte detta köras
                // Detta är default. Körs alltså när du använda Update-Database eller från EfSamurai.App-projektet

                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=SamuraiEF;Integrated Security=True;Pooling=False");
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(sb => new { sb.BattleId, sb.SamuraiId });
        }


    }
}