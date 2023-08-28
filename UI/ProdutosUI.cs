using System;
using System.Collections.Generic;


class ProdutoUI {
    public List<Produto> Produtos;
    private int ContadorID;

    public ProdutoUI() {
        Produtos = new List<Produto>();
        ContadorID = 1;
    }

    public void MostrarMenuProduto() {
        int opcao = 0;
        bool rodando = true;

        while (rodando) {
            Console.Clear();
            Console.WriteLine("===== Menu Produto =====");
            Console.WriteLine("1. Registrar Produto");
            Console.WriteLine("2. Excluir Produto");
            Console.WriteLine("3. Mostrar Produtos");
            Console.WriteLine("4. Atualizar Produto");
            Console.WriteLine("5. Buscar Produto por ID");
            Console.WriteLine("0. Sair da Tela Produto");

            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao) {
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
                case 0:
                    rodando = false; // Sair da tela de produtos
                    break;
                default:
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                    break;
            }
        }
    }

    private void RegistrarProduto() {
        Console.WriteLine("Informe o nome do produto:");
        string nome = Console.ReadLine();

        Console.WriteLine("Informe a descrição do produto:");
        string descricao = Console.ReadLine();

        Console.WriteLine("Informe o preço do produto:");
        decimal preco = Convert.ToDecimal(Console.ReadLine());

        Produto produto = new Produto {
            Id = ContadorID++,
            Nome = nome,
            Descricao = descricao,
            Preco = preco
        };

        Produtos.Add(produto);
        Console.WriteLine("Produto registrado com sucesso!");
    }

    private void ExcluirProduto() {
        Console.WriteLine("Informe o ID do produto que deseja excluir:");
        int idParaExcluir = Convert.ToInt32(Console.ReadLine());

        Produto produtoParaExcluir = Produtos.Find(p => p.Id == idParaExcluir);
        if (produtoParaExcluir != null) {
            Produtos.Remove(produtoParaExcluir);
            Console.WriteLine("Produto excluído com sucesso!");
        } else {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    private void MostrarProdutos() {
        Console.WriteLine("Lista de Produtos:");
        foreach (Produto produto in Produtos) {
            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco}");
        }
    }

    private void AtualizarProduto() {
        Console.WriteLine("Informe o ID do produto que deseja atualizar:");
        int idParaAtualizar = Convert.ToInt32(Console.ReadLine());

        Produto produtoParaAtualizar = Produtos.Find(p => p.Id == idParaAtualizar);
        if (produtoParaAtualizar != null) {
            Console.WriteLine("Informe o novo nome do produto:");
            produtoParaAtualizar.Nome = Console.ReadLine();

            Console.WriteLine("Informe a nova descrição do produto:");
            produtoParaAtualizar.Descricao = Console.ReadLine();

            Console.WriteLine("Informe o novo preço do produto:");
            produtoParaAtualizar.Preco = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Produto atualizado com sucesso!");
        } else {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    private void BuscarProdutoPorID() {
        Console.WriteLine("Informe o ID do produto que deseja buscar:");
        int idParaBuscar = Convert.ToInt32(Console.ReadLine());

        Produto produtoEncontrado = Produtos.Find(p => p.Id == idParaBuscar);
        if (produtoEncontrado != null) {
            Console.WriteLine($"ID: {produtoEncontrado.Id}, Nome: {produtoEncontrado.Nome}, Preço: {produtoEncontrado.Preco}");
        } else {
            Console.WriteLine("Produto não encontrado.");
        }
    }
}

class Program {
    static void Main(string[] args) {
        int opcao = 0;
        bool rodando = true;

        while (rodando) {
            Console.Clear();
            Console.WriteLine("===== Menu Principal =====");
            Console.WriteLine("1. Gerenciar Produtos");
            Console.WriteLine("0. Sair");

            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao) {
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
}
