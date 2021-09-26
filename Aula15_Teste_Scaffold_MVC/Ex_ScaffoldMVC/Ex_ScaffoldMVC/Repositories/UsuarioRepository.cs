using Ex_ScaffoldMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_ScaffoldMVC.Repositories
{
    public interface UsuarioRepository
    {
        Usuario SelecionarPorId(int idUsuario);
    }
}
