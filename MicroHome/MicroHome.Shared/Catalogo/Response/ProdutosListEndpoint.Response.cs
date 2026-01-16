namespace MicroHome.Shared.Catalogo.Response
{
    public class ProdutosListResponse
    {

        public IEnumerable<ProdutoDto> Produtos { get; set; } = Enumerable.Empty<ProdutoDto>();
        public record ProdutoDto(int Id, string Nome, decimal Preco, int Estoque, string Codigo, bool Ativo, bool Promocao);
    }
}
