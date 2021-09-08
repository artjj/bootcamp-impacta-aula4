using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace GerenciamentoDeArquivos.Models
{
    class ArquivoCRUD
    {
        private string Nome;
        //private int Operacao;
        private string CaminhoPadrao = @"C:\teste-arquivos\";
        private string CaminhoCompleto;

        public ArquivoCRUD(string nome)
        {
            Nome = nome;
            //Operacao = operacao;
            CaminhoCompleto = CaminhoPadrao + Nome;
        }

        public void Deletar()
        {
            if (File.Exists(CaminhoCompleto))
            {
                File.Delete(CaminhoCompleto);
                if (!File.Exists(CaminhoCompleto))
                {
                    Console.WriteLine($"Arquivo {Nome} deletado com sucesso!");
                }
                else
                {
                    Console.WriteLine($"Arquivo {Nome} não pôde ser deletado!");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} não existe na pasta de gerenciamento.");
            }
        }

        public void Criar()
        {
            if (!File.Exists(CaminhoCompleto))
            {
                EfetuarCapturaLinhasParaArquivo(null);
                Console.WriteLine($"Arquivo {Nome} criado com sucesso!");
            }
            else
            {
                Console.WriteLine("Arquivo já existente!");
            }
        }

        public void Listar()
        {
            if (File.Exists(CaminhoCompleto))
            {
                using (StreamReader sr = File.OpenText(CaminhoCompleto))
                {
                    string linha;
                    int index = 1;

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine($"Arquivo {Nome} iniciando leitura");

                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"Linha {index++} - Conteúdo: {linha}");
                        //index++;
                    }

                    Console.WriteLine($"Arquivo {Nome} lido com sucesso!");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {Nome} não existe na pasta de gerenciamento.");
            }
        }

        public void Atualizar()
        {
            if (File.Exists(CaminhoCompleto))
            {
                List<string> jaExistente = new List<string>();
                using (StreamReader sr = File.OpenText(CaminhoCompleto))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        jaExistente.Add(linha);
                    }
                }
                EfetuarCapturaLinhasParaArquivo(jaExistente);
                Console.WriteLine($"Arquivoi {Nome} atualizado com sucesso");
            }
        }


        private void EfetuarCapturaLinhasParaArquivo(List<string> jaExistente)
        {
            string linha;
            string concluiuProcesamento;
            bool pararProcessamento = false;
            List<string> linhas;

            if (jaExistente != null && jaExistente.Count > 0)
            {
                linhas = jaExistente;
            }
            else
            {
                linhas = new List<string>();
            }

            do
            {
                Console.WriteLine("Favor informe a linha a ser incluida no arquivo (termine a digitação com enter para a proxima instrução)!");
                linha = Console.ReadLine();

                if (!string.IsNullOrEmpty(linha) || !string.IsNullOrWhiteSpace(linha))
                {
                    Console.WriteLine("Concluiu o preenchimento do arquivo? (S/N)");
                    concluiuProcesamento = Console.ReadLine();
                    if (concluiuProcesamento.Trim().ToUpper() == "S" || concluiuProcesamento.Trim().ToUpper() == "Sim")
                    {
                        pararProcessamento = true;
                    }

                    linhas.Add(linha);
                }
            } while (pararProcessamento == false);

            using (StreamWriter sw = File.CreateText(CaminhoCompleto))
            {
                foreach (var l in linhas)
                {
                    sw.WriteLine(l);
                }
            }
        }
    }
}
