using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste_Scaffold_MVC.Models;

namespace Teste_Scaffold_MVC.Data
{
    public class Teste_Scaffold_MVCContext : DbContext
    {
        public Teste_Scaffold_MVCContext (DbContextOptions<Teste_Scaffold_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Teste_Scaffold_MVC.Models.Movie> Movie { get; set; }
    }
}
