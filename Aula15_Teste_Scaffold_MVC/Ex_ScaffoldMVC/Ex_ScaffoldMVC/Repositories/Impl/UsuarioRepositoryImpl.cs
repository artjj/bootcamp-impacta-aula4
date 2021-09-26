using Ex_ScaffoldMVC.Data;
using Ex_ScaffoldMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_ScaffoldMVC.Repositories.Impl
{
    public class UsuarioRepositoryImpl : UsuarioRepository
    {
        private Ex_ScaffoldMVCContext _context;

        public UsuarioRepositoryImpl(Ex_ScaffoldMVCContext context)
        {
            _context = context;
        }

        public Usuario SelecionarPorId(int idUsuario)
        {
            return _context.Usuario.FirstOrDefault(usuario => usuario.Id == idUsuario);
        }
    }
}
