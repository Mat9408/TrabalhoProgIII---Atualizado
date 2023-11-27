using Microsoft.EntityFrameworkCore;
using SportsECommerce.Models;

namespace SportsECommerce.Data
{
    public class SportsECommerceContext : DbContext
    {
        public SportsECommerceContext(DbContextOptions<SportsECommerceContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
