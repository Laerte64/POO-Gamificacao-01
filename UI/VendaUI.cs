using System;

namespace Gamificacao1
{
    internal class VendaUI
    {
        private int _contadorID;

        public VendaUI()
        {
            _contadorID = 1;

            Venda venda;
            List<(Produto, int)> produtosVendidos;

            produtosVendidos = new List<(Produto, int)> ();
            produtosVendidos.Add((Produto.Lista[0], 2));
            produtosVendidos.Add((Produto.Lista[1], 1));
            venda = new Venda(_contadorID++, Cliente.Lista[0], produtosVendidos);
            Venda.Lista.Add(venda);

            produtosVendidos = new List<(Produto, int)>();
            produtosVendidos.Add((Produto.Lista[2], 1));
            produtosVendidos.Add((Produto.Lista[1], 2));
            venda = new Venda(_contadorID++, Cliente.Lista[1], produtosVendidos);
            Venda.Lista.Add(venda);

            produtosVendidos = new List<(Produto, int)>();
            produtosVendidos.Add((Produto.Lista[0], 1));
            produtosVendidos.Add((Produto.Lista[2], 2));
            venda = new Venda(_contadorID++, Cliente.Lista[2], produtosVendidos);
            Venda.Lista.Add(venda);
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
                    Console.WriteLine("--- Tela de Vendas ---");
                    Console.WriteLine();
                    Console.WriteLine("1 - Listar Vendas;");
                    Console.WriteLine("2 - Buscar por ID;");
                    Console.WriteLine("3 - Adicionar Venda;");
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
                        ListarVendas();
                        break;
                    case 2:
                        BuscarVendaPorID();
                        break;
                    case 3:
                        AdicionarVenda();
                        break;
                    case 4:
                        AlterarVenda();
                        break;
                    case 5:
                        DeletarVenda();
                        break;
                    case 6:
                        rodando = false;
                        break;
                }
            }
        }

        private void ListarVendas()
        {
            Console.WriteLine("Lista de Vendas:");
            Console.WriteLine();
            foreach (var venda in Venda.Lista)
            {
                Console.WriteLine($"ID: {venda.ID}, Cliente: {venda.Cliente.Nome}, Data: {venda.DataVenda}");
                Console.WriteLine("Produtos:");
                foreach ((Produto produto, int quantidade) in venda.ProdutosVendidos)
                {
                    Console.WriteLine($"{quantidade} x {produto.Nome}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void BuscarVendaPorID()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Venda? venda = Venda.Lista.Find(venda => venda.ID == id);

            Console.WriteLine();

            if (venda != null)
            {
                Console.WriteLine("Venda Encontrada:");
                Console.WriteLine($"ID: {venda.ID}, Cliente: {venda.Cliente.Nome}, Data: {venda.DataVenda}");
                Console.WriteLine("Produtos:");
                foreach ((Produto produto, int quantidade) in venda.ProdutosVendidos)
                {
                    Console.WriteLine($"{quantidade} x {produto.Nome}");
                }
            }
            else
            {
                Console.WriteLine($"Venda não encontrada");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void AdicionarVenda()
        {
            Cliente? cliente;
            string input;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID do Cliente que realizou a Venda: ");
                input = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Adição da Venda abortada.");
                    Console.WriteLine();
                    Console.WriteLine("Precione qualquer tecla para retornar.");
                    Console.ReadKey();
                    return;
                }
                int.TryParse(input, out int id);
                cliente = Cliente.Lista.Find(cliente => cliente.ID == id);
            } while (cliente == null);

            List<(Produto, int)> produtosVendidos = new List<(Produto, int)>();
            do
            {
                Console.Clear();
                Console.Write("Insira o ID de em Produto da Venda (vazio para finalizar venda): ");
                input = Console.ReadLine() ?? "";
                input = input.TrimEnd('\n');
                int.TryParse(input, out int id);
                Produto? produto = Produto.Lista.Find(produto => produto.ID == id);

                int quantidade = 0;
                if (!string.IsNullOrEmpty(input))
                {
                    if (produto == null)
                    {
                        continue;
                    }
                    else if (produtosVendidos.FindAll(item => item.Item1.ID == id).Count > 0)
                    {
                        continue;
                    }

                    bool inputValido;
                    do
                    {
                        Console.Clear();
                        Console.Write("Insira a quantida do Produto na Venda: ");
                        input = Console.ReadLine() ?? "";
                        inputValido = int.TryParse(input, out quantidade);
                        if (inputValido && quantidade == 0)
                        {
                            break;
                        }
                    } while (quantidade <= 0);
                }

                if (produto != null && quantidade > 0)
                {
                    produtosVendidos.Add((produto, quantidade));
                }

            } while (!string.IsNullOrEmpty(input));

            if (produtosVendidos.Count == 0)
            {
                Console.WriteLine("Adição da Venda abortada.");
                Console.WriteLine();
                Console.WriteLine("Precione qualquer tecla para retornar.");
                Console.ReadKey();
                return;
            }

            Venda venda = new Venda(_contadorID, cliente, produtosVendidos);
            Venda.Lista.Add(venda);

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void AlterarVenda()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID da Venda que deseja alterar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Venda? venda = Venda.Lista.Find(venda => venda.ID == id);

            Console.WriteLine();

            if (venda == null)
            {
                Console.WriteLine($"Venda não encontrada");
                Console.WriteLine();
                Console.WriteLine("Precione qualquer tecla para retornar.");
                Console.ReadKey();
                return;
            }

            Cliente? cliente = null;
            string input;
            do
            {
                Console.Clear();
                Console.Write("Insira um novo ID do Cliente (vazio para não alterar): ");
                input = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                int.TryParse(input, out id);
                cliente = Cliente.Lista.Find(cliente => cliente.ID == id);
            } while (cliente == null);
            if (cliente != null)
            {
                venda.Cliente = cliente;
            }

            List<(Produto, int)> produtosVendidos = new List<(Produto, int)>();
            do
            {
                Console.Clear();
                Console.Write("Insira o ID de em Produto da Venda (nenhum item para não alterar) (vazio para finalizar venda): ");
                input = Console.ReadLine() ?? "";
                input = input.TrimEnd('\n');
                int.TryParse(input, out id);
                Produto? produto = Produto.Lista.Find(produto => produto.ID == id);

                int quantidade = 0;
                if (!string.IsNullOrEmpty(input))
                {
                    if (produto == null)
                    {
                        continue;
                    }
                    else if (produtosVendidos.FindAll(item => item.Item1.ID == id).Count > 0)
                    {
                        continue;
                    }

                    bool inputValido;
                    do
                    {
                        Console.Clear();
                        Console.Write("Insira a quantida do Produto na Venda: ");
                        input = Console.ReadLine() ?? "";
                        inputValido = int.TryParse(input, out quantidade);
                        if (inputValido && quantidade == 0)
                        {
                            break;
                        }
                    } while (quantidade <= 0);
                }

                if (produto != null && quantidade > 0)
                {
                    produtosVendidos.Add((produto, quantidade));
                }

            } while (!string.IsNullOrEmpty(input));

            if (produtosVendidos.Count > 0)
            {
                venda.ProdutosVendidos = produtosVendidos;
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void DeletarVenda()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Venda? venda = Venda.Lista.Find(venda => venda.ID == id);

            Console.WriteLine();
            if (venda != null)
            {
                Console.WriteLine("Venda Encontrada:");
                Console.WriteLine($"ID: {venda.ID}, Cliente: {venda.Cliente.Nome}, Data: {venda.DataVenda}");
                Console.WriteLine("Produtos:");
                foreach ((Produto produto, int quantidade) in venda.ProdutosVendidos)
                {
                    Console.WriteLine($"{quantidade} x {produto.Nome}");
                }
                Console.WriteLine();
                Console.WriteLine("Tem Certeza? (Para confirmar, \"Sim\") ");
                string verificacao = Console.ReadLine() ?? "";
                if (verificacao.ToUpper() == "SIM")
                {
                    Venda.Lista.RemoveAll(venda => venda.ID == id);
                    Console.WriteLine("Venda deletada com Sucesso.");
                }
                else
                {
                    Console.WriteLine("Deleção Abortada.");
                }
            }
            else
            {
                Console.WriteLine($"Venda não encontrada");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();

        }
    }
}
