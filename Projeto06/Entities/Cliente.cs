using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto06.Entities
{
    //Modelo de dados da entidade Cliente
    public class Cliente
    {
        //atributos da classe
        private Guid _id;
        private string _nome;
        private string _cpf;
        private DateTime _dataNascimento;

        //Método construtor
        public Cliente()
        {
            //gerando o id do cliente
            Id = Guid.NewGuid();

        }

        public Guid Id 
        { 
            get => _id;
            set => _id = value; 
        }
        public string Nome 
        {
            get => _nome; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException
                    ("Nome do cliente é obrigatório");

                var regex = new Regex("^[A-Za-zÀ-Üá-ü\\s]{8,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException
                    ("Nome do cliente inválido. Informe de 8 a 100 caracteres.");

                _nome = value;
            } 
        }
        public string Cpf 
        { 
            get => _cpf; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException
                    ("cpf do cliente é obrigatório.");

                var regex = new Regex("^[0-9]{11}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException
                    ("Cpf do cliente inválido. Informe exatment 11 números.");

                _cpf = value;
            }
        }
        public DateTime DataNascimento 
        {
            get => _dataNascimento; 
            set
            {
                var dataAtual = DateTime.Now; //capturando a data atual
                var idade = dataAtual.Year - value.Year;
                if (idade <= 18 && value > dataAtual.AddYears(-idade))
                    throw new ArgumentException
                    ("O cliente não pode ser menor de idade");

                _dataNascimento = value;
            }
        }
    }
}
