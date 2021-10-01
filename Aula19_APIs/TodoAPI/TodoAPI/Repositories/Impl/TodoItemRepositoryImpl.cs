using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Repositories.Impl
{
    public class TodoItemRepositoryImpl : TodoItemRepository
    {
        private readonly TodoApiDbContext _context;
        public TodoItemRepositoryImpl(TodoApiDbContext context)
        {
            _context = context;
        }

        public async Task Salvar(TodoItem item)
        {
            _context.todoItem.Add(item);
             await _context.SaveChangesAsync();
        }

        public async Task<List<TodoItem>> Listar()
        {
            return await _context.todoItem.ToListAsync();
        }

        public async Task<TodoItem> ListarPorId(int id)
        {
            
            return await _context.todoItem.FindAsync(id);
        }

        public async Task Atualizar(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var query = _context.todoItem.Where(e => e.Id == id);
            _context.todoItem.RemoveRange(query);
            await _context.SaveChangesAsync();
        }
    }
}
