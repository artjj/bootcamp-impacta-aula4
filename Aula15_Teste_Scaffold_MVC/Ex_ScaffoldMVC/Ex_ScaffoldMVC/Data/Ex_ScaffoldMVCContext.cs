using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ex_ScaffoldMVC.Models;

namespace Ex_ScaffoldMVC.Data
{
    public class Ex_ScaffoldMVCContext : DbContext
    {
        public Ex_ScaffoldMVCContext (DbContextOptions<Ex_ScaffoldMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Ex_ScaffoldMVC.Models.Produto> Produto { get; set; }

        public DbSet<Ex_ScaffoldMVC.Models.Usuario> Usuario { get; set; }
    }
}
