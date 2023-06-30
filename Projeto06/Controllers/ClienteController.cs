using Projeto06.Entities;
using Projeto06.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Controllers
{
    public class ClienteController
    {
        public void ExecutarMenu()
        {
            Console.Write("\n *** CONTROLE DE CLIENTES *** \n");
            Console.WriteLine("(1) - Cadastrar Cliente");
            Console.WriteLine("(2) - Atualizar Cliente");
            Console.WriteLine("(3) - Excluir cliente");
            Console.WriteLine("(4) - Consultar clientes");

            try
            {
                Console.WriteLine("\nInforme a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: CadastrarCliente();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para executar o cadastro de um cliente
        private void CadastrarCliente()
        {
            try
            {
                Console.Write("\n *** CADASTRO DE CLIENTE *** \n");

                var cliente = new Cliente();//chamando o método construtor

                Console.Write("\nNome do cliente: ");
                cliente.Nome = Console.ReadLine();


                Console.Write("\nCPF: ");
                cliente.Cpf = Console.ReadLine();


                Console.Write("\nData de nascimento: ");
                cliente.DataNascimento =DateTime.Parse(Console.ReadLine());

                var clienteRepository = new ClienteRepository();
                clienteRepository.Inserir(cliente);

                Console.Write("\nCLIENTE CADASTRADO COM SUCESSO!");
            }
            catch(ArgumentException e)//achar erros nas entidades
            {
                Console.Write("\nOcorreram erros de validação: ");
                Console.Write(e.Message);

            }
            catch(Exception e)
            {
                Console.Write("\nFalha ao cadastrar cliente :" + e.Message);

            }
        }

    }
}
