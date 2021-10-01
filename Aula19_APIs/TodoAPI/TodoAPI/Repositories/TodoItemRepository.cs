using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public interface TodoItemRepository
    {
        public Task Salvar(TodoItem item);
        public Task<List<TodoItem>> Listar();
        public Task<TodoItem> ListarPorId(int id);
        public Task Atualizar(TodoItem item);
         
        public Task Excluir(int id);
    }
}
