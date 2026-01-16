using MicroHome.Catalogo.API.Data;
using MicroHome.Catalogo.API.Model;
using Microsoft.EntityFrameworkCore;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddDbContext<CatalogoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(doc =>
{
    doc.DocumentSettings = docSet =>
    {
        docSet.Title = "MicroHome.Catalogo.API";
        docSet.Version = "V1";
    };
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerGen();
}


using (var scope = app.Services.CreateScope())
{
    var serivces = scope.ServiceProvider;
    var context = serivces.GetRequiredService<CatalogoDbContext>();

    context.Database.Migrate();

    if (!context.Produtos.Any())
    {
        context.Produtos.AddRange(
            new Produtos { Nome = "Luminária Retrô", Preco = 150.00m, Estoque = 10, Codigo = "0000001P", Ativo = true, Promocao = false },
            new Produtos { Nome = "Vaso de Cerâmica", Preco = 85.50m, Estoque = 5, Codigo = "0000002P", Ativo = true, Promocao = true },
            new Produtos { Nome = "Cabideiro Madeira", Preco = 200.00m, Estoque = 12, Codigo = "0000003P", Ativo = true, Promocao = false },
            new Produtos { Nome = "Mesa de Escritório Compacta Luxo", Preco = 300.99m, Estoque = 5, Codigo = "0000004P", Ativo = true, Promocao = true }
        );
        context.SaveChanges();
    }
}

app.Run();