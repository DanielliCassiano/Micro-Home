using MicroHome.Catalogo.API.Data;
using Microsoft.EntityFrameworkCore;
using FastEndpoints;
using MicroHome.Shared.Catalogo.Response;

namespace MicroHome.Catalogo.API.Endpoints
{
    public class ProdutosListEndpoint : EndpointWithoutRequest<ProdutosListResponse>
    {
        private readonly CatalogoDbContext _db;

        public ProdutosListEndpoint(CatalogoDbContext db)
        {
            _db = db;
        }

        public override void Configure()
        {
            Get("/api/produtos");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var produtos = await _db.Produtos
                .AsNoTracking()
                .Select(p => new ProdutosListResponse.ProdutoDto(
                    p.Id, 
                    p.Nome, 
                    p.Preco, 
                    p.Estoque, 
                    p.Codigo, 
                    p.Ativo, 
                    p.Promocao)
                )
                .ToListAsync(ct);

            await HttpContext.Response.WriteAsJsonAsync(new ProdutosListResponse()
            {
                Produtos = produtos
            }, cancellationToken: ct);
        }
    }
}
