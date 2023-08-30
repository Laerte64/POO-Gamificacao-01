using System;

namespace Gamificacao1
{
    internal class Categoria
    {
        public static List<Categoria> Lista = new List<Categoria>();

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Categoria(int id, string nome, string descricao)
        {
            ID = id;
            Nome = nome;
            Descricao = descricao;
        }
    }
}
