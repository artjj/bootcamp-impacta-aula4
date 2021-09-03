using System;
using System.Collections.Generic;
using EntendendoPOO.Models;
using EntendendoPOO.Models.FormaDePagamento;

namespace EntendendoPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            var validade = new DateTime(2021, 9, 20);
            Produto cafe = new Produto()
            {
                Id = 1,
                Nome = "Café 3 Corações",
                Descricao = "Cafe premium torrado embalado a vácuo",
                Tipo = "Alimento",
                Valor = 9.75,
            };
            cafe.AtualizarDataValidade(validade);

            Produto leite = new Produto();
            leite.Id = 2;
            leite.Nome = "Leite UHT Integral";
            leite.Descricao = "Leite integral pasteurizado";
            leite.Tipo = "Alimento";
            leite.Valor = 4.85;
            leite.AtualizarDataValidade(new DateTime(2021, 9, 13));

            if (!cafe.IsProdutoValido())
            {
                Console.WriteLine("Café vencido!");
            }

            if (!leite.IsProdutoValido())
            {
                Console.WriteLine("Leite vencido!");
            }

            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nome = "Arthur Dylan",
                IsMaiorDeIdade = true
            };

            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nome = "User",
                Demissao = null
            };

            List<Pessoa> pessoas = new List<Pessoa>();

            //pessoas.Add(cliente);
            //pessoas.Add(usuario);

            foreach(var p in pessoas)
            {
                if (p is Cliente)
                {
                    Console.WriteLine($"Cliente: {p.Nome}, é maior de idade? {((Cliente)p).IsMaiorDeIdade}");
                }
                else if (p is Usuario)
                {
                    Console.WriteLine($"Usuario: {p.Nome}, é maior de idade? {((Usuario)p).Demissao}");
                }
                else
                {
                    Console.WriteLine($"Pessoa: {p.Nome}");
                }
            }

            Console.WriteLine("Digite a forma de pagamento desejada: (1 - Credito, 2 - Debito, 3 - VA, 4 - Dinheiro, 5 - PIX) ");
            try
            {
                var tipoDePagamento = int.Parse(Console.ReadLine());

                FormaDePagamento pagamento;

                switch (tipoDePagamento)
                {
                    case 1:
                        pagamento = new FormaDePagamentoCredito();
                        break;
                    case 2:
                        pagamento = new FormaDePagamentoDebito();
                        break;
                    case 3:
                        pagamento = new FormaDePagamentoVA();
                        break;
                    case 4:
                        pagamento = new FormaDePagamentoDinheiro();
                        break;
                    case 5:
                        pagamento = new FormaDePagamentoPix();
                        break;
                    default:
                        throw new Exception("Nenhuma forma de pagamento encontrada!");
                }
                pagamento.EfetuarPagamento();
            } 
            catch (FormatException fe)
            {
                Console.WriteLine("Erro na formatação!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argumento nulo!");
            }
            finally
            {
                Console.WriteLine("Terminou o try!");
            }
            
            

            ValidationUtil<string> validation1 = new ValidationUtil<string>();
            validation1.isValid("teste");

            ValidationUtil<int> validation2 = new ValidationUtil<int>();
            validation2.isValid(12);

            ValidationUtil<bool> validation3 = new ValidationUtil<bool>();
            validation3.isValid(true);
        }
    }
}
