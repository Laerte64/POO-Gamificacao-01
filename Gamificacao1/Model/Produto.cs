using System;

namespace Gamificacao1
{
    internal class Produto
    {
        public static List<Produto> Lista = new List<Produto>();

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Categoria Categoria { get; set; }

        public Produto(int id, string nome, string descricao, decimal preco, Categoria categoria)
        {
            ID = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Categoria = categoria;
        }
    }
}