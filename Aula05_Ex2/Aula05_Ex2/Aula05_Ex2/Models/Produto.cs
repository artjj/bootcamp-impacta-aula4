using System;
using System.Collections.Generic;
using System.Text;

namespace Aula05_Ex2
{
    class Produto
    {
        public string Nome { get; set; }

        public DateTime DataDeValidade { get; set; }

        public double Preco { get; set; }
        public string Marca { get; set; }

        public Produto(string nome, DateTime dataDeValidade, double preco, string marca)
        {
            Nome = nome;
            DataDeValidade = dataDeValidade;
            Preco = preco;
            Marca = marca;
        }
    }
}
