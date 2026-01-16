using MicroHome.Pedido.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PedidoEntityTypeConfig : IEntityTypeConfiguration<Pedidos>
{
    public void Configure(EntityTypeBuilder<Pedidos> builder)
    {
        builder
            .Property(pe => pe.Id)
            .IsRequired();
    }
}