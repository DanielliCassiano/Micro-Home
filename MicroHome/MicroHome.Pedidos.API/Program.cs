using MicroHome.Pedido.API.Data;
using MicroHome.Pedido.API.Model;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<PedidoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var serivces = scope.ServiceProvider;
    var context = serivces.GetRequiredService<PedidoDbContext>();

    context.Database.Migrate();

    if (!context.Pedidos.Any())
    {
        context.Pedidos.AddRange(
            new Pedidos { ProdutoId = 1, Quantidade = 2, ValorTotal =  300.00m},
            new Pedidos { ProdutoId = 3, Quantidade = 1, ValorTotal = 200.00m },
            new Pedidos { ProdutoId = 2, Quantidade = 4, ValorTotal = 340.00m }
        );
        context.SaveChanges();
    }
}

app.Run();
