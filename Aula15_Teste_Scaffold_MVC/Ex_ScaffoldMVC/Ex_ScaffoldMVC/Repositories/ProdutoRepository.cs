using Ex_ScaffoldMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_ScaffoldMVC.Repositories
{
    public interface ProdutoRepository
    {
        List<Produto> ObterProdutos();
        Produto SelecionarProdutoPorId(int idProduto);
        List<Produto> ObterItensPorProduto();
    }
}
