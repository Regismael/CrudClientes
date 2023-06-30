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
                Console.Write("\nInforme a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: CadastrarCliente();
                        break;
                    case 2: AtualizarCliente();
                        break;
                    case 3: ExcluirCliente();
                        break;
                    case 4: ConsultarCliente();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }

                Console.Write("\nDESEJA CONTINUAR? (S,N): ");
                var escolha = Console.ReadLine();

                if (escolha.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    ExecutarMenu();

                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA!");

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
        //Método para executar a edição de um cliente
        public void AtualizarCliente()
        {
            try
            {
                Console.WriteLine("\n*** EDIÇÃO DE CLIENTE ***\n");

                Console.Write("INFORME O ID DO CLIENTE: ");
                var id = Guid.Parse(Console.ReadLine());

                //pesquisar no banco de dados o cliente através do id
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(id);

                //verificar se o cliente foi encontrado
                if(cliente != null)
                {
                    Console.Write("INFORME O NOME DO CLIENTE: ");
                    cliente.Nome = Console.ReadLine();

                    Console.Write("INFORME O CPF DO CLIENTE: ");
                    cliente.Cpf = Console.ReadLine();

                    Console.WriteLine("INFORME A DATA DE NASCIMENTO: ");
                    cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

                    //atualizando o cliente no banco de dados
                    clienteRepository.Atualizar(cliente);

                    Console.Write("\nCLIENTE AUALIZADO COM SUCESSO.");

                }
                else
                {
                    Console.WriteLine("\nCliente não encontrado.");
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("\nOcorreram erros de validação");
            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha ao atualizar cliente: " + e.Message);
            }
        }

        //método para executar a exclusão de um cliente
        public void ExcluirCliente()
        {
            try
            {
                Console.WriteLine("\n*** EXCLUSÃO DE CLIENTE ***\n");

                Console.Write("INFORME O ID DO CLIENTE: ");
                var id = Guid.Parse(Console.ReadLine());

                //pesquisar o cliente no banco de dados através do id
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(id);

                if(cliente != null)
                {
                    //excluiro cliente
                    clienteRepository.Excluir(cliente);

                    Console.WriteLine("\nCLIENTE EXCLUÍDO COM SEUCESSO.");

                }
                else
                {

                }
            }
            catch(Exception e)
            {
                Console.Write("\nFalha ao excluir cliente: " + e.Message);
            }
            
        }
        //metódo para consultar e imprmir todos os clientes cadastrados

        public void ConsultarCliente()
        {
            try
            {
                Console.WriteLine("\n *** CONSULTA DE CLIENTES ***");

                //consultando todos os clientes cadastrados no banco de dados
                var clienteRepository = new ClienteRepository();
                var clientes = clienteRepository.ObterTodos();

                //varrer e imprimir a lista de clientes:
                foreach (var item in clientes)
                {
                    Console.WriteLine("ID: " + item.Id);
                    Console.WriteLine("NOME: " + item.Nome);
                    Console.WriteLine("CPF: " +item.Cpf);
                    Console.WriteLine("DATA DE NASC: " + item.DataNascimento);
                    Console.WriteLine("...");
                }
             
            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha ao consultar cliente" + e.Message);

            }
        } 
    }
}
