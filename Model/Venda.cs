using System;

namespace Gamificacao1
{
    internal class Venda
    {
        public static List<Venda> Lista = new List<Venda>();

        public int ID { get; set; }
        public Cliente Cliente { get; set; }
        public List<(Produto, int)> ProdutosVendidos { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }

        public Venda(int id, Cliente cliente, List<(Produto, int)> produtosVendidos)
        {
            ID = id;
            Cliente = cliente;
            ProdutosVendidos = produtosVendidos;
            DataVenda = DateTime.Today;

            ValorTotal = 0;
            foreach ((Produto produto, int quantidade) in produtosVendidos)
            {
                ValorTotal += quantidade * produto.Preco;
            }
        }
    }
}