using APICatalogo5._0.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo5._0.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public AppDbContext()
        {

        }


        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}