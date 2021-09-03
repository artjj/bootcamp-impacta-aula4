using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoPOO.Models.FormaDePagamento
{
    class FormaDePagamentoPix : FormaDePagamento
    {
        public override void EfetuarPagamento()
        {
            Console.WriteLine("Pagamento efetuado com PIX!");
        }
    }
}
