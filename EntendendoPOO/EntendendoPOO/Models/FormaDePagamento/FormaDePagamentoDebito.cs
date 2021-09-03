using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoPOO.Models.FormaDePagamento
{
    class FormaDePagamentoDebito : FormaDePagamento, IFormaDePagamentoCartao
    {
        public void IsCartaoComSaldo()
        {
            Console.WriteLine("Cartão com saldo.!");
        }
        public override void EfetuarPagamento()
        {
            IsCartaoComSaldo();
            Console.WriteLine("Pagamento efetuado com Cartão de Debito!");
        }
    }
}
