using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoPOO.Models
{
    class Produto
    {
        public int Id;
        public string Nome;
        public string Descricao;
        public double Peso;
        public double Valor;
        public DateTime Validade { get; private set; }
        public string Tipo;

        public Produto()
        {

        }
        public Produto(int id, string nome, string descricao, double peso, double valor, DateTime validade, string tipo)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Peso = peso;
            Valor = valor;
            Validade = validade;
            Tipo = tipo;
        }

        public string ExibirDados()
        {
            return "Id: " + Id 
                + ", Nome: " + Nome 
                + ", Descrição: " + Descricao 
                + ", Peso: " + Peso 
                + ", Valor: $" + Valor 
                + ", Validade: " + Validade; 
        }

        public void AtualizarDataValidade(DateTime novaData)
        {
            Validade = novaData;
        }

        public bool IsProdutoValido()
        {
            return Validade > DateTime.Now;
        }
    }
}
