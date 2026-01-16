using MicroHome.Catalogo.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class CatalogoEntityTypeConfig : IEntityTypeConfiguration<Produtos>
{
    public void Configure(EntityTypeBuilder<Produtos> builder)
    {
        builder
            .Property(pro => pro.Id)
            .IsRequired();
    }
}