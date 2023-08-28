using System;
using System.Collections.Generic;



    class ProdutoUI
    {
        public List<Produto> Produtos;
        private int ContadorID;

        public ProdutoUI()
        {
            Produtos = new List<Produto>();
            ContadorID = 1;
        }

        public void MostrarMenuProduto()
        {
            int opcao = 0;
            bool rodando = true;

            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("===== Menu Produto =====");
                Console.WriteLine("1. Registrar Produto");
                Console.WriteLine("2. Excluir Produto");
                Console.WriteLine("3. Mostrar Produtos");
                Console.WriteLine("4. Atualizar Produto");
                Console.WriteLine("5. Buscar Produto por ID");
                Console.WriteLine("6. Sair da Tela Produto");

                opcao = ObterInteiroDaEntrada("Opção: ");

                switch (opcao)
                {
                    case 1:
                        RegistrarProduto();
                        break;
                    case 2:
                        ExcluirProduto();
                        break;
                    case 3:
                        MostrarProdutos();
                        break;
                    case 4:
                        AtualizarProduto();
                        break;
                    case 5:
                        BuscarProdutoPorID();
                        break;
                    case 6:
                        rodando = false; // Sair da tela de produtos
                        break;
                    default:
                        Console.WriteLine("Escolha inválida. Tente novamente.");
                        break;
                }
            }
        }

        private int ObterInteiroDaEntrada(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Insira um número inteiro válido.");
                }
            }
        }

        private decimal ObterDecimalDaEntrada(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Insira um número decimal válido.");
                }
            }
        }

        private void RegistrarProduto()
        {

            string nome;
            do
            {
                Console.Clear();
                Console.Write("Insira o nome do Produto: ");
                nome = Console.ReadLine() ?? "";
                nome = nome.TrimEnd('\n');
            }while(string.IsNullOrWhiteSpace(nome));

            
            string descricao;
            do
            {
                Console.Clear();
                Console.Write("Insira a descrição do Produto: ");
                descricao = Console.ReadLine() ?? "";
                descricao = descricao.TrimEnd('\n');
            }while(string.IsNullOrWhiteSpace(descricao));

            int preco;
            bool inputValido
            do
            {
                Console.Clear();
                Console.Write("Insira a descrição do Produto: ");
                string input = Console.ReadLine() ?? "";
                inputValido = int.TryParse(input, out preco);
            }
            while(!inputValido);

            Produto produto = new Produto
            {
                Id = ContadorID++,
                Nome = nome,
                Descricao = descricao,
                Preco = preco
            };

            Produtos.Add(produto);
            Console.WriteLine("Produto registrado com sucesso!");
        }

        private void ExcluirProduto()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "0";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Produto produto = Produto.Find(produto => produto.Id == id);

            Console.WriteLine();

            if (produto != null)
            {
                Console.WriteLine("Produto Encontrada:");
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Descrição: {produto.Descricao}");
                Console.WriteLine("Tem Certeza? (Para confirmar, \"Sim\") ");
                string? verificacao = Console.ReadLine();
                if (verificacao.ToUpper() == "SIM")
                {
                    Categorias.RemoveAll(produto => produto.Id == id);
                    Console.WriteLine("Produto deletada com Sucesso.");
                }
                else
                {
                    Console.WriteLine("Deleção Abortada.");
                }
            }
            else
            {
                Console.WriteLine($"Produto não encontrado");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
            

        private void MostrarProdutos()
        {
            Console.WriteLine("Lista de Produtos:");
            foreach (Produto produto in Produtos)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco}");
            }
        }

        private void AtualizarProduto()
        {
            int idParaAtualizar = ObterInteiroDaEntrada("Informe o ID do produto que deseja atualizar: ");

            Produto produtoParaAtualizar = Produtos.Find(p => p.Id == idParaAtualizar);
            if (produtoParaAtualizar != null)
            {
                Console.WriteLine("Informe o novo nome do produto:");
                produtoParaAtualizar.Nome = Console.ReadLine();

                Console.WriteLine("Informe a nova descrição do produto:");
                produtoParaAtualizar.Descricao = Console.ReadLine();

                decimal novoPreco = ObterDecimalDaEntrada("Informe o novo preço do produto: ");
                produtoParaAtualizar.Preco = novoPreco;

                Console.WriteLine("Produto atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        private void BuscarProdutoPorID()
        {
            int idParaBuscar = ObterInteiroDaEntrada("Informe o ID do produto que deseja buscar: ");

            Produto produtoEncontrado = Produtos.Find(p => p.Id == idParaBuscar);
            if (produtoEncontrado != null)
            {
                Console.WriteLine($"ID: {produtoEncontrado.Id}, Nome: {produtoEncontrado.Nome}, Preço: {produtoEncontrado.Preco}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            bool rodando = true;

            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("===== Menu Principal =====");
                Console.WriteLine("1. Gerenciar Produtos");
                Console.WriteLine("0. Sair");

                opcao = ObterInteiroDaEntrada("Opção: ");

                switch (opcao)
                {
                    case 1:
                        ProdutoUI produtoUI = new ProdutoUI();
                        produtoUI.MostrarMenuProduto();
                        break;
                    case 0:
                        Console.WriteLine("Encerrando o programa.");
                        rodando = false;
                        break;
                    default:
                        Console.WriteLine("Escolha inválida. Tente novamente.");
                        break;
                }
            }
        }

        private static int ObterInteiroDaEntrada(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Insira um número inteiro válido.");
                }
            }
        }
    }

