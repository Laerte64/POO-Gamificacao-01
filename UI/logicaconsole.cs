using System;
using System.Collections.Generic;

public static class ProdutoUI {
    public static void MostrarMenuProduto() {
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

    private static void RegistrarProduto() {
        
    }

    private static void ExcluirProduto() {
        
    }

    private static void MostrarProdutos() {
        
    }
}
