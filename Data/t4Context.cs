using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using t4.Model;
using System;

namespace t4.Data
{
    public class t4Context : DbContext
    {
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-S8TDV4N;Initial Catalog=T4;Persist Security Info=True;user id=sa;password=ST1PL2;Integrated Security=true;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer4>().HasKey(a => a.Id4);
        }

        public DbSet<Offer4> Offer4 { get; set; }
    }
}