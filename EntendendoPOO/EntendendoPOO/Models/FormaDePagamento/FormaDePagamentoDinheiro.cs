using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoPOO.Models.FormaDePagamento
{
    class FormaDePagamentoDinheiro : FormaDePagamento
    {
        public override void EfetuarPagamento()
        {
            Console.WriteLine("Pagamento efetuado com Dinheiro!");
        }
    }
}
