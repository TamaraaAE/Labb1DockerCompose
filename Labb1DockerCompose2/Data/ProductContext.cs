
using Labb1DockerCompose2.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1DockerCompose2.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
    }
}
