using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Mercado.Dto
{
    public class SalvarUsuarioDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }
    }
}
