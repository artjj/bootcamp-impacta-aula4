using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_JWT.Models
{
    public class Teste_JWTDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public Teste_JWTDbContext(DbContextOptions<Teste_JWTDbContext> options) : base(options)
        {

        }
    }
}
