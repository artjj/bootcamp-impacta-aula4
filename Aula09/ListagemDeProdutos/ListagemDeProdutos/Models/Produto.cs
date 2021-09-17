using System;
using System.Collections.Generic;
using System.Text;

namespace ListagemDeProdutos.Models
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataValidade { get; set; }
        public double Valor { get; set; }
    }
}
