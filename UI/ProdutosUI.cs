using System;

namespace Gamificacao1
{
    internal class ProdutoUI
    {
        private int _contadorID;

        public ProdutoUI()
        {
            _contadorID = 1;

            Produto produto;
            produto = new Produto(_contadorID++, "Camisa Apolo", "Camisa com argola", 52.80m, Categoria.Lista[0]);
            Produto.Lista.Add(produto);
            produto = new Produto(_contadorID++, "Shorts Nike", "Shorts com logo da Nike", 39.50m, Categoria.Lista[2]);
            Produto.Lista.Add(produto);
            produto = new Produto(_contadorID++, "Calça jeans", "Calça jeans masculina", 44.20m, Categoria.Lista[1]);
            Produto.Lista.Add(produto);
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
                    Console.WriteLine("--- Tela de Produtos ---");
                    Console.WriteLine();
                    Console.WriteLine("1 - Listar Produtos;");
                    Console.WriteLine("2 - Buscar por ID;");
                    Console.WriteLine("3 - Adicionar Produto;");
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
                        ListarProdutos();
                        break;
                    case 2:
                        BuscarProdutoPorID();
                        break;
                    case 3:
                        AdicionarProduto();
                        break;
                    case 4:
                        AlterarProduto();
                        break;
                    case 5:
                        DeletarProduto();
                        break;
                    case 6:
                        rodando = false;
                        break;
                }
            }
        }

        private void ListarProdutos()
        {
            Console.WriteLine("Lista de Produtos:");
            Console.WriteLine();
            foreach (var produto in Produto.Lista)
            {
                Console.WriteLine($"ID: {produto.ID}, Nome: {produto.Nome}, Descrição: {produto.Descricao}, Preço: {produto.Preco}, Categoria: {produto.Categoria.Nome}");
            }
            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void BuscarProdutoPorID()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Produto? produto = Produto.Lista.Find(produto => produto.ID == id);

            Console.WriteLine();

            if (produto != null)
            {
                Console.WriteLine("Produto Encontrado:");
                Console.WriteLine($"ID: {produto.ID}, Nome: {produto.Nome}, Descrição: {produto.Descricao}, Preço: {produto.Preco}, Categoria: {produto.Categoria.Nome}");
            }
            else
            {
                Console.WriteLine($"Produto não encontrado");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void AdicionarProduto()
        {
            string nome;
            do
            {
                Console.Clear();
                Console.Write("Insira o nome do Produto: ");
                nome = Console.ReadLine() ?? "";
                nome = nome.TrimEnd('\n');
            } while (string.IsNullOrEmpty(nome));

            string descricao;
            do
            {
                Console.Clear();
                Console.Write("Insira a descrição do Produto: ");
                descricao = Console.ReadLine() ?? "";
                descricao = descricao.TrimEnd('\n');
            } while (string.IsNullOrEmpty(descricao));

            decimal preco;
            bool inputValido;
            do
            {
                Console.Clear();
                Console.Write("Insira o preço do Produto: ");
                string input = Console.ReadLine() ?? "";
                inputValido = decimal.TryParse(input, out preco);
            } while (!inputValido || preco < 0);

            Categoria? categoria;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID da categoria do Produto (vazio para cancelar): ");
                string input = Console.ReadLine() ?? "";
                input = input.TrimEnd('\n');
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine();
                    Console.WriteLine("Adição de Produto cancelada.");
                    Console.WriteLine();
                    Console.WriteLine("Precione qualquer tecla para retornar.");
                    Console.ReadKey();
                    return;
                }
                int.TryParse(input, out int id);
                categoria = Categoria.Lista.Find(categoria => categoria.ID == id);
            } while (categoria == null);

            Produto produto = new Produto(_contadorID++, nome, descricao, preco, categoria);
            Produto.Lista.Add(produto);

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void AlterarProduto()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID do Produto que deseja alterar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Produto? produto = Produto.Lista.Find(produto => produto.ID == id);

            Console.WriteLine();

            if (produto == null)
            {
                Console.WriteLine($"Produto não encontrado");
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
                produto.Nome = nome;
            }

            Console.Clear();
            Console.Write("Insira uma nova Descrição (deixe vazio para não alterar): ");
            string descricao = Console.ReadLine() ?? "";
            descricao = descricao.TrimEnd('\n');
            if (!string.IsNullOrEmpty(descricao))
            {
                produto.Descricao = descricao;
            }

            decimal preco;
            string input;
            bool inputValido;
            do
            {
                Console.Clear();
                Console.Write("Insira um novo preço (deixe vazio para não alterar): ");
                input = Console.ReadLine() ?? "";
                inputValido = decimal.TryParse(input, out preco);
            } while ((!inputValido || preco < 0) && !string.IsNullOrEmpty(input));
            if (inputValido)
            {
                produto.Preco = preco;
            }

            Categoria? categoria;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID da categoria do Produto (vazio para não alterar): ");
                input = Console.ReadLine() ?? "";
                input = input.TrimEnd('\n');
                categoria = Categoria.Lista.Find(categoria => categoria.ID == id);
            } while (categoria == null && !string.IsNullOrEmpty(input));
            if (categoria != null)
            {
                produto.Categoria = categoria;
            }

            Console.Clear();
            Console.WriteLine("Produto Atualizado:");
            Console.WriteLine();
            Console.WriteLine($"ID: {produto.ID}, Nome: {produto.Nome}, Descrição: {produto.Descricao}, Preço: {produto.Preco}, Categoria: {produto.Categoria.Nome}");
            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void DeletarProduto()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Produto? produto = Produto.Lista.Find(produto => produto.ID == id);

            Console.WriteLine();
            if (produto != null)
            {
                Console.WriteLine("Produto Encontrado:");
                Console.WriteLine($"ID: {produto.ID}, Nome: {produto.Nome}, Descrição: {produto.Descricao}, Preço: {produto.Preco}, Categoria: {produto.Categoria.Nome}");
                Console.WriteLine("Tem Certeza? (Para confirmar, \"Sim\") ");
                string verificacao = Console.ReadLine() ?? "";
                if (verificacao.ToUpper() == "SIM")
                {
                    Produto.Lista.RemoveAll(produto => produto.ID == id);
                    Console.WriteLine("Produto deletado com Sucesso.");
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

        }
    }
}
