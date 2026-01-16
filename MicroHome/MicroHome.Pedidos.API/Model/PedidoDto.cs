namespace MicroHome.Catalogo.API.Model
{
    public class PedidoDto
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
