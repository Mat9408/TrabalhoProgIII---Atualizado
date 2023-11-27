namespace SportsECommerce.Models
{
    public interface IProduto
    {
        long? ProdutoID { get; set; }
        string ProdutoNome { get; set; }
        string ProdutoModelo { get; set; }
        decimal ProdutoPreco { get; set; }
    }

    public class Produto : IProduto
    {
        public long? ProdutoID { get; set; }
        public string ProdutoNome { get; set; }
        public string ProdutoModelo { get; set; }
        public decimal ProdutoPreco { get; set; } 

    }
}
