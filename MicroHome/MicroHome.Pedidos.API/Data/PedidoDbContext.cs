using MicroHome.Pedido.API.Model;
using Microsoft.EntityFrameworkCore;

namespace MicroHome.Pedido.API.Data
{
    public class PedidoDbContext : DbContext
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options) { }
        public DbSet<Pedidos> Pedidos { get; set; }
    }
}
