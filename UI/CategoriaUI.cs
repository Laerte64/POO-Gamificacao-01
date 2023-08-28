using System;
using System.Security.Cryptography.X509Certificates;

namespace Gamificacao1
{
    static class CategoriaUI
    {
        static public List<Categoria> Categorias = new List<Categoria>();;
        static private int ContadorID = 1;

        static private void AdicionarCategoria()
        {
            string nome;
            do
            {
                Console.Clear();
                Console.Write("Insira o nome da Categoria: ");
                nome = Console.ReadLine() ?? "";
                nome = nome.TrimEnd('\n');
            } while (string.IsNullOrEmpty(nome));

            string descricao;
            do
            {
                Console.Clear();
                Console.Write("Insira a descrição da Categoria: ");
                descricao = Console.ReadLine() ?? "";
                descricao = descricao.TrimEnd('\n');
            } while (string.IsNullOrEmpty(descricao));

            Categoria categoria = new Categoria(ContadorID, nome, descricao);
            Categorias.Add(categoria);
            ContadorID++;

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        static private void DeletarCategoria()
        {
            int id = 0;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "0";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Categoria categoria = Categorias.Find(categoria => categoria.Id == id);

            Console.WriteLine();

            if (categoria != null)
            {
                Console.WriteLine("Categoria Encontrada:");
                Console.WriteLine($"ID: {categoria.Id}, Nome: {categoria.Nome}, Descrição: {categoria.Descricao}");
                Console.WriteLine("Tem Certeza? (Para confirmar, \"Sim\") ");
                string? verificacao = Console.ReadLine();
                if (verificacao.ToUpper() == "SIM")
                {
                    Categorias.RemoveAll(categoria => categoria.Id == id);
                    Console.WriteLine("Categoria deletada com Sucesso.");
                }
                else
                {
                    Console.WriteLine("Deleção Abortada.");
                }
            }
            else
            {
                Console.WriteLine($"Categoria não encontrada");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();

        }

        static private void AlterarCategoria()
        {
            int id = -1;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID da Categoria que deseja alterar: ");
                string entrada = Console.ReadLine() ?? "0";
                int.TryParse(entrada, out id);
            } while (id < 0);

            Categoria? categoria = Categorias.Find(categoria => categoria.Id == id);

            Console.WriteLine();

            if (categoria == null)
            {
                Console.WriteLine($"Categoria não encontrada");
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
                categoria.Nome = nome;
            }

            Console.Clear();
            Console.Write("Insira a descrição da Categoria: ");
            string descricao = Console.ReadLine() ?? "";
            descricao = descricao.TrimEnd('\n');
            if (!string.IsNullOrEmpty(descricao))
            {
                categoria.Descricao = descricao;
            }
        }

        static private void ListarCategorias()
        {
            Console.WriteLine("Lista de Categorias:");
            Console.WriteLine();
            foreach (var categoria in Categorias)
            {
                Console.WriteLine($"ID: {categoria.Id}, Nome: {categoria.Nome}, Descrição: {categoria.Descricao}");
            }
            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        static private void BuscarCategoriaPorID()
        {
            int id = 0;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "0";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Categoria categoria = Categorias.Find(categoria => categoria.Id == id);

            Console.WriteLine();

            if (categoria != null)
            {
                Console.WriteLine("Categoria Encontrada:");
                Console.WriteLine($"ID: {categoria.Id}, Nome: {categoria.Nome}, Descrição: {categoria.Descricao}");
            }
            else
            {
                Console.WriteLine($"Categoria não encontrada");
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
                Console.WriteLine("--- Tela de Categorias ---");
                Console.WriteLine();
                Console.WriteLine("1 - Listar Categorias;");
                Console.WriteLine("2 - Buscar por ID;");
                Console.WriteLine("3 - Adicionar Categoria;");
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
                Console.Clear();
                switch (opcao)
                {
                    case 0:
                        opcao = MenuPrincipal();
                        break;
                    case 1:
                        ListarCategorias();
                        opcao = 0;
                        break;
                    case 2:
                        BuscarCategoriaPorID();
                        opcao = 0;
                        break;
                    case 3:
                        AdicionarCategoria();
                        opcao = 0;
                        break;
                    case 4:
                        AlterarCategoria();
                        opcao = 0;
                        break;
                    case 5:
                        DeletarCategoria();
                        opcao = 0;
                        break;
                    case 6:
                        rodando = false;
                        break;
                }
            }
        }
    }
}
