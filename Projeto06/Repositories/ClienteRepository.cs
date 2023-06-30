using Dapper;
using Projeto06.Entities;
using Projeto06.Settings;
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
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //executando o comando INSERT no banco de dados
                connection.Execute(query, cliente);

            }

        }

        //método para atualizar um cliente no banco de dados
        public void Atualizar(Cliente cliente)
        {
            var query = @"
            UPDATE CLIENTE
            SET
                NOME = @Nome,
                CPF = @Cpf,
                DATANASCIMENTO = @DataNascimento
            WHERE
                ID = @Id
        ";
            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //executando o comando Sql no banco de dados
                connection.Execute(query, cliente);
            }
        }

        //método para excluir um cliente no banco de dados
        public void Excluir(Cliente cliente)
        {
            var query = @"

                DELETE FROM CLIENTE
                
             WHERE 
                ID = @Id

             ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, cliente);
            }
        }

        //método para retornar uma lista com todos os clientes cadastrados
        public List<Cliente> ObterTodos()
        {
            var query = @"
                    SELECT * FROM CLIENTE
                    ORDER BY NOME
        ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Cliente>(query).ToList();
            }
        }

        //método para retornar um cliente baseado no ID
        public Cliente? ObterPorId(Guid id)
        {
            var query = @"
                SELECT * FROM CLIENTE
              
                WHERE ID = @Id

             ";

            //abrindo conexão com o banco de dados
            using( var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Cliente>(query, new { @Id = id }).FirstOrDefault();
            }
        }
    }
}
