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
            // ...

            Console.WriteLine("0. Voltar ao Menu Principal");
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
                case 0:
                    rodando = false;
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

        Console.WriteLine("Informe a categoria do produto:");
        string categoriaNome = Console.ReadLine();

        Categoria categoria = new Categoria {
            Id = ContadorID++,
            Nome = categoriaNome
        };

        Produto produto = new Produto {
            Id = ContadorID++,
            Nome = nome,
            Descricao = descricao,
            Preco = preco,
            Categoria = categoria
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
}
