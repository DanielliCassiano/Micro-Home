namespace MicroHome.Catalogo.API.Model
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public bool Promocao { get; set; } 
    }
}
