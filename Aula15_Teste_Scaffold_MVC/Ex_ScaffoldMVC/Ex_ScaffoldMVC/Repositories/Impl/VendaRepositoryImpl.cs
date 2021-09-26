using Microsoft.EntityFrameworkCore;
using Ex_ScaffoldMVC.Dtos;
using Ex_ScaffoldMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex_ScaffoldMVC.Data;

namespace Ex_ScaffoldMVC.Repositories.Impl
{
    public class VendaRepositoryImpl : VendaRepository
    {
        private Ex_ScaffoldMVCContext _context;

        public VendaRepositoryImpl(Ex_ScaffoldMVCContext context)
        {
            _context = context;
        }

        public void Salvar(Venda venda)
        {
            _context.Venda.Add(venda);
            _context.SaveChanges();
        }

        public void Atualizar(Venda venda)
        {
            _context.Entry(venda).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(venda).State = EntityState.Detached;
        }

        public List<VendaPorUsuarioDto> ObterVendasPorUsuario()
        {
            return _context.Usuario.Include(e => e.Vendas).Select(e => new VendaPorUsuarioDto() { 
                Nome = e.Nome,
                QtdDeVendas = e.Vendas.Count(),
                ValorToralVendas = e.Vendas.Sum(e => e.Total),
                Vendas = e.Vendas
            }).ToList();
        }
    }
}
