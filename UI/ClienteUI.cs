using System;

namespace Gamificacao1
{
    internal class ClienteUI
    {
        private int _contadorID;

        public ClienteUI()
        {
            _contadorID = 1;

            Cliente cliente;
            cliente = new Cliente(_contadorID++, "João", "Santos", "R. Iguaçu 3140", "3264-9897");
            Cliente.Lista.Add(cliente);
            cliente = new Cliente(_contadorID++, "Maria", "Bragança", "R. Amazonas 1880", "3264-4142");
            Cliente.Lista.Add(cliente);
            cliente = new Cliente(_contadorID++, "Lucas", "Silva", "R. Sergipe 2305", "4546-9192");
            Cliente.Lista.Add(cliente);
        }

        public void Tela()
        {
            int opcao;
            bool rodando = true;

            while (rodando)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("--- Tela de Clientes ---");
                    Console.WriteLine();
                    Console.WriteLine("1 - Listar Clientes;");
                    Console.WriteLine("2 - Buscar por ID;");
                    Console.WriteLine("3 - Adicionar Clientes;");
                    Console.WriteLine("4 - Atualizar por ID;");
                    Console.WriteLine("5 - Deletar por ID;");
                    Console.WriteLine("6 - Retornar ao Menu Principal.");
                    Console.WriteLine();
                    Console.Write("Selecione uma opção: ");

                    string entrada = Console.ReadLine() ?? "";
                    int.TryParse(entrada, out opcao);
                } while (opcao <= 0 || opcao > 6);

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        ListarClientes();
                        break;
                    case 2:
                        BuscarClientePorID();
                        break;
                    case 3:
                        AdicionarCliente();
                        break;
                    case 4:
                        AlterarCliente();
                        break;
                    case 5:
                        DeletarCliente();
                        break;
                    case 6:
                        rodando = false;
                        break;
                }
            }
        }

        private void ListarClientes()
        {
            Console.WriteLine("Lista dos Clientes:");
            Console.WriteLine();
            foreach (var cliente in Cliente.Lista)
            {
                Console.WriteLine($"ID: {cliente.ID}, Nome: {cliente.Nome} {cliente.Sobrenome}, Endereço: {cliente.Endereco}, Telefone: {cliente.NumeroTelefone}");
            }
            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void BuscarClientePorID()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Cliente? cliente = Cliente.Lista.Find(cliente => cliente.ID == id);

            Console.WriteLine();

            if (cliente != null)
            {
                Console.WriteLine("Cliente Encontrado:");
                Console.WriteLine($"ID: {cliente.ID}, Nome: {cliente.Nome} {cliente.Sobrenome}, Endereço: {cliente.Endereco}, Telefone: {cliente.NumeroTelefone}");
            }
            else
            {
                Console.WriteLine($"Cliente não encontrado");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void AdicionarCliente()
        {
            string nome;
            do
            {
                Console.Clear();
                Console.Write("Insira o nome do Cliente: ");
                nome = Console.ReadLine() ?? "";
                nome = nome.TrimEnd('\n');
            } while (string.IsNullOrEmpty(nome));

            string sobrenome;
            do
            {
                Console.Clear();
                Console.Write("Insira a descrição do Cliente: ");
                sobrenome = Console.ReadLine() ?? "";
                sobrenome = sobrenome.TrimEnd('\n');
            } while (string.IsNullOrEmpty(sobrenome));

            string endereco;
            do
            {
                Console.Clear();
                Console.Write("Insira o endereço do Cliente: ");
                endereco = Console.ReadLine() ?? "";
                endereco = endereco.TrimEnd('\n');
            } while (string.IsNullOrEmpty(endereco));

            string numeroTelefone;
            do
            {
                Console.Clear();
                Console.Write("Insira o número de telefone do Cliente: ");
                numeroTelefone = Console.ReadLine() ?? "";
                numeroTelefone = numeroTelefone.TrimEnd('\n');
            } while (string.IsNullOrEmpty(numeroTelefone));

            Cliente cliente = new Cliente(_contadorID++, nome, sobrenome, endereco, numeroTelefone);
            Cliente.Lista.Add(cliente);

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void AlterarCliente()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID do Cliente que deseja alterar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Cliente? cliente = Cliente.Lista.Find(cliente => cliente.ID == id);

            Console.WriteLine();

            if (cliente == null)
            {
                Console.WriteLine($"Cliente não encontrado");
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
            Console.Write("Insira um novo Sobrenome (deixe vazio para não alterar): ");
            string sobrenome = Console.ReadLine() ?? "";
            sobrenome = sobrenome.TrimEnd('\n');
            if (!string.IsNullOrEmpty(sobrenome))
            {
                cliente.Sobrenome = sobrenome;
            }

            Console.Clear();
            Console.Write("Insira um novo Endereço (deixe vazio para não alterar): ");
            string endereco = Console.ReadLine() ?? "";
            endereco = endereco.TrimEnd('\n');
            if (!string.IsNullOrEmpty(endereco))
            {
                cliente.Endereco = endereco;
            }

            Console.Clear();
            Console.Write("Insira um novo Número de Telefone (deixe vazio para não alterar): ");
            string numeroTelefone = Console.ReadLine() ?? "";
            numeroTelefone = numeroTelefone.TrimEnd('\n');
            if (!string.IsNullOrEmpty(numeroTelefone))
            {
                cliente.NumeroTelefone = numeroTelefone;
            }

            Console.Clear();
            Console.WriteLine("Cliente Atualizado:");
            Console.WriteLine();
            Console.WriteLine($"ID: {cliente.ID}, Nome: {cliente.Nome} {cliente.Sobrenome}, Endereço: {cliente.Endereco}, Telefone: {cliente.NumeroTelefone}");
            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void DeletarCliente()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Cliente cliente = Cliente.Lista.Find(cliente => cliente.ID == id);

            Console.WriteLine();
            if (cliente != null)
            {
                Console.WriteLine("Cliente Encontrado:");
                Console.WriteLine($"ID: {cliente.ID}, Nome: {cliente.Nome} {cliente.Sobrenome}, Endereço: {cliente.Endereco}, Telefone: {cliente.NumeroTelefone}");
                Console.WriteLine("Tem Certeza? (Para confirmar, \"Sim\") ");
                string verificacao = Console.ReadLine() ?? "";
                if (verificacao.ToUpper() == "SIM")
                {
                    Categoria.Lista.RemoveAll(categoria => categoria.ID == id);
                    Console.WriteLine("Cliente deletado com Sucesso.");
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
    }
}
