using Ex_ScaffoldMVC.Data;
using Ex_ScaffoldMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_ScaffoldMVC.Repositories.Impl
{
    public class VendaItemRepositoryImpl : VendaItemRepository
    {
        private Ex_ScaffoldMVCContext _context;

        public VendaItemRepositoryImpl(Ex_ScaffoldMVCContext context)
        {
            _context = context;
        }

        public void Salvar(VendaItem item)
        {
            _context.VendaItem.Add(item);
            _context.SaveChanges();
        }
    }
}
