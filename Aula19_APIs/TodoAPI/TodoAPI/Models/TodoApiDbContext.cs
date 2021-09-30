using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoApiDbContext : DbContext
    {
        public DbSet<TodoItem> todoItem { get; set; }
        public TodoApiDbContext(DbContextOptions<TodoApiDbContext> options) : base(options)
        {

        }
    }
}
