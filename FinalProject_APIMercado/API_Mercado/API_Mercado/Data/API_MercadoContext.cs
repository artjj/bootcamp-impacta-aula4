using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Mercado.Models;

namespace API_Mercado.Data
{
    public class API_MercadoContext : DbContext
    {
        public API_MercadoContext (DbContextOptions<API_MercadoContext> options)
            : base(options)
        {
        }

        public DbSet<API_Mercado.Models.Produto> Produto { get; set; }

        public DbSet<API_Mercado.Models.Venda> Venda { get; set; }

        public DbSet<API_Mercado.Models.VendaItem> VendaItem { get; set; }

        public DbSet<API_Mercado.Models.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationshitp in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationshitp.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
