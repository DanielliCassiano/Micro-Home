using MicroHome.Catalogo.API.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace MicroHome.Catalogo.API.Data
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options) { }
        public DbSet<Produtos> Produtos { get; set; }
    }
}
