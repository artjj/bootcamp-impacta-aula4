using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TesteDapper.Models;

namespace TesteDapper
{
    class DapperService
    {
        public string Conexao { get; set; }
        public Aluno Aluno { get; set; }
        public DapperService(string conexao)
        {
            Conexao = conexao;
        }
        public void Consultar()
        {
            using (var db = new SqlConnection(Conexao))
            {
                db.Open();
                var query = "Select ID, NOME, DATA_NASCIMENTO From TB_ALUNO";
                var alunos = db.Query<Aluno>(query);

                foreach (var aluno in alunos)
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("ID: " + aluno.Id.ToString());
                    Console.WriteLine("Nome : " + aluno.Nome);
                    Console.WriteLine("Data de Nascimento: " + aluno.Data_Nascimento.ToShortDateString());
                    Console.WriteLine("----------------------------------------------------");
                }
            }
        }

        public void Incluir()
        {
            Console.WriteLine($"Digite o Nome do novo Aluno: ");
            var nome = Console.ReadLine();

            Console.WriteLine($"Digite a Data de Nascimento do novo Aluno (dd/mm/yyyy):");
            var dataNasc = DateTime.Parse(Console.ReadLine());

            Aluno = new Aluno(nome, dataNasc);

            using (var db = new SqlConnection(Conexao))
            {

                try
                {
                    db.Open();
                    var query = $"Insert Into TB_ALUNO(NOME,DATA_NASCIMENTO) Values('{Aluno.Nome}','{Aluno.Data_Nascimento.ToShortDateString()}')";
                    Console.WriteLine(query);
                    db.Execute(query);

                    Console.WriteLine($"Aluno {Aluno.Nome} incluido com sucesso");
                }
                catch (Exception ex)
                {
                    throw ex;
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Atualizar()
        {
            Console.WriteLine("Digite o Id do Aluno a ser alterado: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o novo Nome do Aluno (ID {id}): ");
            var nomeAluno = Console.ReadLine();

            Console.WriteLine($"Digite a nova Data de Nascimento do Aluno (ID {id}) (dd/mm/yyyy):");
            var dataNasc = DateTime.Parse(Console.ReadLine());

            Aluno = new Aluno(id, nomeAluno, dataNasc);

            using (var db = new SqlConnection(Conexao))
            {
                try
                {
                    db.Open();
                    var query = $"Update TB_ALUNO Set Nome='{Aluno.Nome}', DATA_NASCIMENTO='{Aluno.Data_Nascimento.ToShortDateString()}' Where ID={Aluno.Id}";

                    db.Execute(query);

                    Console.WriteLine($"Aluno {Aluno.Nome} incluido com sucesso");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Deletar()
        {
            Console.WriteLine("Digite o Id do Aluno a ser deletado: ");
            var id = int.Parse(Console.ReadLine());

            using (var db = new SqlConnection(Conexao))
            {
                try
                {
                    db.Open();
                    var query = @"Delete from TB_ALUNO Where ID=" + id;
                    db.Execute(query);

                    Console.WriteLine($"Aluno excluido com sucesso");
                    Consultar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
