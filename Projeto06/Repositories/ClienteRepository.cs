using Dapper;
using Projeto06.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Repositories
{
    //classe de repositorio para banco de dados
    public class ClienteRepository
    {
        //método para cadastrar um cliente no banco de dados
        public void Inserir(Cliente cliente)
        {
            //escrevendo o comando SQL que será executado no banco de dados
            var query = @"
                INSERT INTO CLIENTE(ID, NOME, CPF, DATANASCIMENTO)
                VALUES(@Id, @Nome, @Cpf, @DataNascimento)
            ";

            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProjeto06;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                //executando o comando INSERT no banco de dados
                connection.Execute(query, cliente);

            }

        }

    }
}
