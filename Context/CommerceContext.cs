using Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace commerce.Context
{
    public class CommerceContext : DbContext
    {
        public CommerceContext(DbContextOptions<CommerceContext> options) : base(options)
        {

        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Saller> Sallers { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Carne Bovina",
                    Description = "Carne Bovina para Churrasco",
                    Value = 12
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Batata Palha - 1Kg",
                    Description = "Batata Palha - 1Kg",
                    Value = 29
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Queijo Parmesão - 5,5Kg",
                    Description = "Queijo Parmesão - 5,5Kg",
                    Value = 300
                }
            );
             
            modelBuilder.Entity<Saller>().HasData(
                new Saller
                {
                    SallerId = 1,
                    NameSaller = "Person",
                    Cpf = "000.000.000-00",
                    Email = "string",
                    Active = true,
                    Telephone = "0000000-0000",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                 new Saller
                {
                    SallerId = 2,
                    NameSaller = "Roberto",
                    Cpf = "000.000.000-00",
                    Email = "string",
                    Active = true,
                    Telephone = "0000000-0000",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                 new Saller
                {
                    SallerId = 3,
                    NameSaller = "Gabriela",
                    Cpf = "000.000.000-00",
                    Email = "string",
                    Active = true,
                    Telephone = "0000000-0000",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
             );
        }

    }
}