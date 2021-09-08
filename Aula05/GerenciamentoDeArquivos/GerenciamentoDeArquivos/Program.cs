using GerenciamentoDeArquivos.Models;
using System;
using System.IO;

namespace GerenciamentoDeArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            //var caminhoDoArquivo = @"C:\teste-arquivos\teste.txt";

            try
            {
                Console.Write("Digite o nome do arquivo que vai ser gerenciado (ex. nome.txt /teste.csv): ");
                var nome = Console.ReadLine();

                if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome) || nome.Length < 5 || (!nome.Contains(".txt") && !nome.Contains(".csv")))
                {
                    Console.WriteLine("Nome inválido, tente novamente!");
                    return;
                }

                Console.Write("Favor informe a operação a realizar (1 - deletar, 2 - criar, 3 - atualizar e 4 - selecionar): ");
                var operacao = int.Parse(Console.ReadLine());

                var arquivo = new ArquivoCRUD(nome);
                switch (operacao)
                {
                    case 1:
                        arquivo.Deletar();
                        break;
                    case 2:
                        arquivo.Criar();
                        break;
                    case 3:
                        arquivo.Atualizar();
                        break;
                    case 4:
                        arquivo.Listar();
                        break;
                    default:
                        throw new ArgumentException("Valor informado não é um dos numeros disponíveis, refaça a operação!");
                }

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Numero informado nulo. Refaça a operação!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Número informado não é um nenhum dos itens informados!");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Número informado é maior que um inteiro!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            ////Criar e preencher o arquivo caso ele não exista
            //if (!File.Exists(caminhoDoArquivo))
            //{
            //    using (StreamWriter sw = File.CreateText(caminhoDoArquivo))
            //    {
            //        sw.WriteLine("Meu primeiro txt em C#");
            //        sw.WriteLine("Minha segunda linha");
            //        sw.WriteLine("Minha terceira linha");
            //    }
            //}

            ////Ler o arquivo gerado e imprimir no console
            //using (StreamReader sr = File.OpenText(caminhoDoArquivo))
            //{
            //    string line;
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //}
        }
    }
}
