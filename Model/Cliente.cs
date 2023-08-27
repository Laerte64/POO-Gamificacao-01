using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificacao1
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string NumeroTelefone { get; set; }

        public Cliente(int id, string nome, string sobrenome, string endereco, string numeroTelefone)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            NumeroTelefone = numeroTelefone;
        }
    }
}
