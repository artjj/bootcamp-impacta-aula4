using System;
using Dapper;
using TesteDapper.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace TesteDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var Configuration = builder.Build();
            string _con = Configuration["ConnectionStrings:DefaultConnection"];

            DapperService dapper = new DapperService(_con);
            string op;
            do
            {
                Console.Write("Escolha a operação (c - Consultar, a - Atualizar, i - Inserir, d - Deletar): ");
                switch (Console.ReadLine())
                {
                    case "c":
                        dapper.Consultar();
                        break;
                    case "i":

                        Console.WriteLine($"Digite o Nome do novo Aluno: ");
                        var nome = Console.ReadLine();

                        Console.WriteLine($"Digite a Data de Nascimento do novo Aluno (dd/mm/yyyy):");
                        var dataNasc = DateTime.Parse(Console.ReadLine());

                        dapper.Aluno = new Aluno(nome, dataNasc);

                        dapper.Incluir();
                        break;

                    case "a":
                        Console.WriteLine("Digite o Id do Aluno a ser alterado: ");
                        var id = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o novo Nome do Aluno (ID {id}): ");
                        nome = Console.ReadLine();

                        Console.WriteLine($"Digite a nova Data de Nascimento do Aluno (ID {id}) (dd/mm/yyyy):");
                        dataNasc = DateTime.Parse(Console.ReadLine());

                        dapper.Aluno = new Aluno(id, nome, dataNasc);
                        dapper.Atualizar();
                        break;

                    case "d":

                        Console.WriteLine("Digite o Id do Aluno a ser deletado: ");
                        id = int.Parse(Console.ReadLine());
                        dapper.Aluno.Id = id;
                        dapper.Deletar();
                        break;
                }
                Console.WriteLine("Deseja realizar mais operações? (S/N)");
                op = Console.ReadLine();
            } while (op.ToUpper() == "S" || op.ToUpper() == "s");

        }
    }
}
