using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_Teste_3.Pages
{
    public class Index2Model : PageModel
    {
        public string Message { get; private set; }
        public void OnGet()
        {
            Message = "A Data do Servidor é (Dado retornado utilizando o Model): " + DateTime.Now.ToLongDateString();
        }
    }
}
