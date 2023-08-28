using System;
using System.Collections.Generic;

class ProdutoUI {
    private static List<Produto> produtos = new List<Produto>();
    private static int produtoIdCounter = 1;

    public static void RegistrarProduto() {
        Console.WriteLine("Informe o nome do produto:");
        string nome = Console.ReadLine();

        Console.WriteLine("Informe a descrição do produto:");
        string descricao = Console.ReadLine();

        Console.WriteLine("Informe o preço do produto:");
        decimal preco = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Informe a categoria do produto:");
        string categoriaNome = Console.ReadLine();

        Categoria categoria = new Categoria {
            Id = produtoIdCounter++, 
            Nome = categoriaNome
        };

        Produto produto = new Produto {
            Id = produtoIdCounter++,
            Nome = nome,
            Descricao = descricao,
            Preco = preco,
            Categoria = categoria
        };

        produtos.Add(produto);
        Console.WriteLine("Produto registrado com sucesso!");
    }

    public static void ExcluirProduto() {
        Console.WriteLine("Informe o ID do produto que deseja excluir:");
        int idParaExcluir = Convert.ToInt32(Console.ReadLine());

        Produto produtoParaExcluir = produtos.Find(p => p.Id == idParaExcluir);
        if (produtoParaExcluir != null) {
            produtos.Remove(produtoParaExcluir);
            Console.WriteLine("Produto excluído com sucesso!");
        } else {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    public static void MostrarProdutos() {
        Console.WriteLine("Lista de Produtos:");
        foreach (Produto produto in produtos) {
            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco}");
        }
    }

    public static void MostrarMenuProduto() {
        while (true) {
            Console.WriteLine("===== Menu Produto =====");
            Console.WriteLine("1. Registrar Produto");
            Console.WriteLine("2. Excluir Produto");
            Console.WriteLine("3. Mostrar Produtos"); 
            // ...

            Console.WriteLine("0. Voltar ao Menu Principal");
            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha) {
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
                    return; 
                default:
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                    break;
            }
        }
    }
}
