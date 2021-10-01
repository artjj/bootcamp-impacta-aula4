using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Repositories.Impl
{
    public class ITesteImpl : ITeste
    {
        public void Mensagem()
        {
            Console.WriteLine("Realizando teste de DI!");
        }
    }
}
