using System;

namespace Gamificacao1
{
    internal class Cliente
    {
        public static List<Cliente> Lista = new List<Cliente>();

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string NumeroTelefone { get; set; }

        public Cliente(int id, string nome, string sobrenome, string endereco, string numeroTelefone)
        {
            ID = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            NumeroTelefone = numeroTelefone;
        }
    }
}