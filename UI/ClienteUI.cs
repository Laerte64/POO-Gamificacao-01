using System;
using System.Collections.Generic;
using System.Linq;

namespace Gamificacao1
{

    class ClienteUI
    {
         private static List<Cliente> Clientes = new List<Cliente>;
         private static int ContadorId = 0;

         public ClienteUI 
         { 
	        Clientes = new List<Cliente>();

         }

        public void AdicionarCliente()
        {

        //Id Nome Sobrenome Endereco NumeroTelefone 
            string nome;

            do
            {
                Console.Clear();
                Console.Write("Insira o nome do cliente: ");
                nome = Console.ReadLine() ?? "";
                nome = nome.TrimEnd('\n');

            } while (string.IsNullOrEmpty(nome));

            string sobrenome;

            do
            {
                Console.Clear();
                Console.Write("Insira o sobrenome: ");
                sobrenome = Console.ReadLine() ?? "";
                sobrenome = descricao.TrimEnd('\n');

            } while (string.IsNullOrEmpty(sobrenome));

            string endereco;

            do
            {
                Console.Clear();
                Console.Write("Insira o Endereço: ");
                endereco = Console.ReadLine() ?? "";
                endereco = descricao.TrimEnd('\n');

            } while (string.IsNullOrEmpty(endereco));

            string numeroTelefone


            do
            {
                Console.Clear();
                Console.Write("Insira o Telefone: ");
                numeroTelefone = Console.ReadLine() ?? "";
                numeroTelefone = descricao.TrimEnd('\n');

            } while (string.IsNullOrEmpty(numeroTelefone));

            Cliente cliente = new(ContadorId, nome, sobrenome, endereco, numeroTelefone);
            Clientes.Add(cliente)
            ContadorID++;

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();

        }

        public void RemoverCliente()
        {

            int id = 0;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID do cliente para procurar: ");
                string entrada = Console.ReadLine() ?? "0";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Cliente cliente = Clientes.Find(cliente => cliente.Id == id);

            Console.WriteLine();

            if (client != null)
            {
                Console.WriteLine("Cliente encontrado:");
                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome} {cliente.Nome}, Endereço: {cliente.Endereco}, Telefone: {cliente.NumeroTelefone}");
                Console.WriteLine("Tem Certeza? (Para confirmar, \"Sim\") ");
                string? verificacao = Console.ReadLine();
                if (verificacao.ToUpper() == "SIM")
                {
                    Clientes.RemoveAll(cliente => cliente.Id == id);
                    Console.WriteLine("Cliente deletadO com Sucesso.");
                }
                else
                {
                    Console.WriteLine("Deleção Abortada.");
                }
            }
            else
            {
                Console.WriteLine($"Cliente não encontrado");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();


        }

        static private void BuscarClientePorID()
        {
            int id = 0;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "0";
                int.TryParse(entrada, out id);

            } while (id <= 0);

            Cliente cliente = Categorias.Find(categoria => categoria.Id == id);

            Console.WriteLine();

            if (cliente != null)
            {
                Console.WriteLine("Cliente encontrado:");
                Console.WriteLine($"  ID: {cliente.Id}, Nome: {cliente.Nome} {cliente.Sobrenome}, Endereço: {cliente.Endereco}, Telefone: {cliente.NumeroTelefone} ");
            }
            else
            {
                Console.WriteLine($"Cliente não encontrado");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();

        }

        static private void AlterarCliente()
        {
            int id;
            bool inputValido;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID do cliente que deseja alterar: ");
                string entrada = Console.ReadLine() ?? "";
                inputValido = int.TryParse(entrada, out id);
            } while (!inputValido);

            Cliente? cliente = Clientes.Find(cliente => cliente.Id == id);

            Console.WriteLine();

            if (cliente == null)
            {

                Console.WriteLine($"Cliente não encontrada");
                Console.WriteLine();
                Console.WriteLine("Precione qualquer tecla para retornar.");
                Console.ReadKey();
                return;

            }

            Console.Clear();
            Console.Write("Insira um novo Nome (deixe vazio para não alterar): ");
            string nome = Console.ReadLine() ?? "";
            nome = nome.TrimEnd('\n');
            if (!string.IsNullOrEmpty(nome))
            {
                cliente.Nome = nome;
            }

            Console.Clear();
            Console.Write("Insira um novo Sobrenome(deixe vazio para não alterar): ");
            string sobrenome = Console.ReadLine() ?? "";
            sobrenome = sobrenome.TrimEnd('\n');
            if (!string.IsNullOrEmpty(sobrenome))
            {
                cliente.Sobrenome = sobrenome;
            }

            Console.Clear();
            Console.Write("Insira um novo endereço(deixe vazio para não alterar): ");
            string sobrenome = Console.ReadLine() ?? "";
            endereco = endereco.TrimEnd('\n');
            if (!string.IsNullOrEmpty(endereco))
            {
                cliente.Endereco = endereco;
            }

            Console.Clear();
            Console.Write("Insira um novo telefone(deixe vazio para não alterar): ");
            string numeroTelefone = Console.ReadLine() ?? "";
            numeroTelefone = endereco.TrimEnd('\n');
            if (!string.IsNullOrEmpty(numeroTelefone))
            {
                cliente.NumeroTelefone = numeroTelefone;
            }

        }

        public ListarClientes()
        {
            Console.WriteLine("Lista de Clientes:");
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"  ID: {cliente.Id}, Nome: {cliente.Nome} {cliente.Sobrenome}, Endereço: {cliente.Endereco}, Telefone: {cliente.Telefone}");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }


        static public int MenuPrincipal()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("--- Tela de Categorias ---\n");
             
                Console.WriteLine("1 - Listar clientes;");
                Console.WriteLine("2 - Buscar por ID;");
                Console.WriteLine("3 - Adicionar cliente;");
                Console.WriteLine("4 - Atualizar por ID;");
                Console.WriteLine("5 - Deletar por ID;");
                Console.WriteLine("6 - Retornar ao Menu Principal.");
                Console.WriteLine();
                Console.WriteLine("Selecione uma opção");

                string entrada = Console.ReadLine() ?? "0";
                int.TryParse(entrada, out opcao);
            } while (opcao > 6 || opcao <= 0);
            return opcao;
        }

        static public void Tela()
            {
                int opcao = 0;
                bool rodando = true;


                while (rodando)
                {






                }
            


            }

        }
}