using Microsoft.EntityFrameworkCore;
using Ex_ScaffoldMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex_ScaffoldMVC.Data;

namespace Ex_ScaffoldMVC.Repositories.Impl
{
    public class ProdutoRepositoryImpl : ProdutoRepository
    {
        private Ex_ScaffoldMVCContext _context;

        public ProdutoRepositoryImpl(Ex_ScaffoldMVCContext context)
        {
            _context = context;
        }

        public List<Produto> ObterItensPorProduto()
        {
            return _context.Produto.Include(e => e.ItensDoProdutoVendido).ToList();
        }

        public List<Produto> ObterProdutos()
        {
            return _context.Produto.Where(produto => produto.Validade > DateTime.Now).ToList();
        }

        public Produto SelecionarProdutoPorId(int idProduto)
        {
            return _context.Produto.FirstOrDefault(produto => produto.Id == idProduto);
        }
    }
}
