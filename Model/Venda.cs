using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificacao1
{
    internal class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<Produto> ProdutosVendidos { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }

        public Venda(int id, Cliente cliente, List<Produto> produtosVendidos, DateTime dataVenda)
        {
            Id = id;
            Cliente = cliente;
            ProdutosVendidos = produtosVendidos;
            DataVenda = dataVenda;

            ValorTotal = 0;
            foreach (Produto produto in produtosVendidos)
            {
                ValorTotal += produto.Preco;
            }
        }
    }
}
