using Gamificacao1;

class Program
{
    public static void Main()
    {
        CategoriaUI categoriaUI = new CategoriaUI();
        ClienteUI clienteUI = new ClienteUI();
        ProdutoUI produtoUI = new ProdutoUI();
        VendaUI vendaUI = new VendaUI();

        int opcao;
        bool rodando = true;
        while (rodando)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("--- Tela de Menus ---");
                Console.WriteLine();
                Console.WriteLine("1 - Categorias;");
                Console.WriteLine("2 - Clientes;");
                Console.WriteLine("3 - Produtos;");
                Console.WriteLine("4 - Vendas;");
                Console.WriteLine("5 - Sair do Programa.");
                Console.WriteLine();
                Console.Write("Selecione uma opção: ");

                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out opcao);
            } while (opcao <= 0 || opcao > 5);

            switch (opcao)
            {
                case 1:
                    categoriaUI.Tela();
                    break;
                case 2:
                    clienteUI.Tela();
                    break;
                case 3:
                    produtoUI.Tela();
                    break;
                case 4:
                    vendaUI.Tela();
                    break;
                case 5:
                    rodando = false;
                    break;
            }
        }
    }
}