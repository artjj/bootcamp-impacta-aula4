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
            try
            {
                do
                {
                    Console.Write("Escolha a operação (c - Consultar, a - Atualizar, i - Inserir, d - Deletar): ");

                    switch (Console.ReadLine())
                    {
                        case "c":
                            dapper.Consultar();
                            break;
                        case "i":

                            dapper.Incluir();
                            break;

                        case "a":
                            dapper.Atualizar();
                            break;

                        case "d":
                            dapper.Deletar();
                            break;
                        default:
                            new Exception("Operação inválida!");
                            break;
                    }
                    Console.WriteLine("Deseja continuar? (S/N)");
                    op = Console.ReadLine();
                } while (op.ToUpper() == "S" || op.ToUpper() == "s");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
