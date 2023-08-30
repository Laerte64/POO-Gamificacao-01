using System;

namespace Gamificacao1
{
    internal class CategoriaUI
    {
        private int _contadorID;

        public CategoriaUI()
        {
            _contadorID = 1;

            Categoria categoria;
            categoria = new Categoria(_contadorID++, "Camisas", "Camisas masculinas e femininas, de P até G");
            Categoria.Lista.Add(categoria);
            categoria = new Categoria(_contadorID++, "Calças", "Calsas de todos os tamanhos");
            Categoria.Lista.Add(categoria);
            categoria = new Categoria(_contadorID++, "Shorts", "Shorts jeans e de praia");
            Categoria.Lista.Add(categoria);
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
                    Console.WriteLine("--- Tela de Categorias ---");
                    Console.WriteLine();
                    Console.WriteLine("1 - Listar Categorias;");
                    Console.WriteLine("2 - Buscar por ID;");
                    Console.WriteLine("3 - Adicionar Categoria;");
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
                        ListarCategorias();
                        break;
                    case 2:
                        BuscarCategoriaPorID();
                        break;
                    case 3:
                        AdicionarCategoria();
                        break;
                    case 4:
                        AlterarCategoria();
                        break;
                    case 5:
                        DeletarCategoria();
                        break;
                    case 6:
                        rodando = false;
                        break;
                }
            }
        }

        private void ListarCategorias()
        {
            Console.WriteLine("Lista de Categorias:");
            Console.WriteLine();
            foreach (var categoria in Categoria.Lista)
            {
                Console.WriteLine($"ID: {categoria.ID}, Nome: {categoria.Nome}, Descrição: {categoria.Descricao}");
            }
            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void BuscarCategoriaPorID()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Categoria? categoria = Categoria.Lista.Find(categoria => categoria.ID == id);

            Console.WriteLine();

            if (categoria != null)
            {
                Console.WriteLine("Categoria Encontrada:");
                Console.WriteLine($"ID: {categoria.ID}, Nome: {categoria.Nome}, Descrição: {categoria.Descricao}");
            }
            else
            {
                Console.WriteLine($"Categoria não encontrada");
            }

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void AdicionarCategoria()
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

            Categoria categoria = new Categoria(_contadorID++, nome, descricao);
            Categoria.Lista.Add(categoria);

            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void AlterarCategoria()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID da Categoria que deseja alterar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Categoria? categoria = Categoria.Lista.Find(categoria => categoria.ID == id);

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
            Console.Write("Insira a descrição da Categoria (deixe vazio para não alterar): ");
            string descricao = Console.ReadLine() ?? "";
            descricao = descricao.TrimEnd('\n');
            if (!string.IsNullOrEmpty(descricao))
            {
                categoria.Descricao = descricao;
            }

            Console.Clear();
            Console.WriteLine("Categoria Atualizada:");
            Console.WriteLine();
            Console.WriteLine($"ID: {categoria.ID}, Nome: {categoria.Nome}, Descrição: {categoria.Descricao}");
            Console.WriteLine();
            Console.WriteLine("Precione qualquer tecla para retornar.");
            Console.ReadKey();
        }

        private void DeletarCategoria()
        {
            int id;
            do
            {
                Console.Clear();
                Console.Write("Insira o ID para procurar: ");
                string entrada = Console.ReadLine() ?? "";
                int.TryParse(entrada, out id);
            } while (id <= 0);

            Categoria categoria = Categoria.Lista.Find(categoria => categoria.ID == id);

            Console.WriteLine();
            if (categoria != null)
            {
                Console.WriteLine("Categoria Encontrada:");
                Console.WriteLine($"ID: {categoria.ID}, Nome: {categoria.Nome}, Descrição: {categoria.Descricao}");
                Console.WriteLine("Tem Certeza? (Para confirmar, \"Sim\") ");
                string verificacao = Console.ReadLine() ?? "";
                if (verificacao.ToUpper() == "SIM")
                {
                    Categoria.Lista.RemoveAll(categoria => categoria.ID == id);
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
    }
}
