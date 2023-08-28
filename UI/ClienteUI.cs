using System;
using System.Collections.Generic;
using System.Linq;

namespace Gamificacao1
{

    class ClienteUI
    {
        private static List<Cliente> Clientes = new List<Cliente>;

        private static int ContadorId = 1;

    }

    public ClienteUI { 

		Clientes = new List<Cliente>();

	}

public void AdicionarCliente(int id, string nome, string sobrenome, string endereco, string numeroTelefone)
{

    Cliente cliente = new Cliente(id, nome, sobrenome, endereco, numeroTelefone);
    Clientes.Add(cliente);

    //Console.WriteLine("Cliente adicionado com sucesso!");
}

public void RemoverCliente(int id)
{
    Cliente clienteRemover = clientes.Find(cliente => cliente.Id == id);

    if (clienteRemover != null)
    {
        clientes.Remove(clienteRemover);
        Console.WriteLine("Cliente removido com sucesso!");
    }
    else
    {
        Console.WriteLine("Cliente não encontrado.");
    }

}

    public ListarClientes()
    {
        Console.WriteLine("Lista de Clientes:");
        foreach (Cliente cliente in clientes)
        {
        Console.WriteLine($"  ID: {cliente.Id}, Nome: {cliente.Nome} {cliente.Sobrenome}, Endereço: {cliente.Endereco}, Telefone: {cliente.Telefone}");
        }

    }

}