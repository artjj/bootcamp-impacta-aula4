using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TesteDapper.Models
{
    class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }

        public Aluno(string nome, DateTime data_Nascimento)
        {
            Nome = nome;
            Data_Nascimento = data_Nascimento;
        }

        public Aluno(int id, string nome, DateTime data_Nascimento)
        {
            Id = id;
            Nome = nome;
            Data_Nascimento = data_Nascimento;
        }
    }
}
