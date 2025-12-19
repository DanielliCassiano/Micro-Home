namespace MicroHome.Pedido.API.Model
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
