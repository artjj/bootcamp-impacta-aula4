using ExercicioEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioEF
{
    class ExercicioEFDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Cargo> Cargo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("data source=DESKTOP-J0917JE\\SQLEXPRESS;initial catalog=EXERCICIO_ENTITY;trusted_connection=true");
        }
    }
}
