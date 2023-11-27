using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Domain.Entities;

namespace TrincaChurras.Infra.Data.Contexts
{
    public class TrincaChurrasContext : DbContext
    {

        public TrincaChurrasContext(DbContextOptions<TrincaChurrasContext> options) : base(options)
        {
        }

        public DbSet<Churrasco> Churrascos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseCosmos("AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", databaseName: "DbChurrasco");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Churrasco>()
                .ToContainer("Churrascos")
                .HasPartitionKey(x => x.Id);

            modelBuilder.Entity<Churrasco>().OwnsMany(x => x.Participantes);

            modelBuilder.Entity<User>()
                .ToContainer("Users")
                .HasPartitionKey(x => x.Id);
        }
    }
}
