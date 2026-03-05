using Cafeteria.Models;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Adicione DbSets aqui conforme necessário, por exemplo:
        // public DbSet<Produto> Produtos { get; set; }
        public DbSet<Barista> Baristas { get; set; }
        public DbSet<Cafe> Cafes { get; set; }
        public DbSet<Venda> Vendas { get; set; }

    }
    
}

