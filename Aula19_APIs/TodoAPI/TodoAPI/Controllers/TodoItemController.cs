﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;
using TodoAPI.Repositories;
using TodoAPI.Repositories.Impl;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly TodoItemRepository _todoItemRepository;
        private readonly ITeste _teste;

        public TodoItemController(TodoItemRepository todoItemRepository, ITeste teste)
        {
            _todoItemRepository = todoItemRepository;
            _teste = teste;
        }

        // GET: api/TodoItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GettodoItem()
        {
            _teste.Mensagem();
            return await _todoItemRepository.Listar();
        }

        // GET: api/TodoItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            
            TodoItem todoItem = await _todoItemRepository.ListarPorId(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // PUT: api/TodoItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            

            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await _todoItemRepository.Atualizar(todoItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            //_context.todoItem.Add(todoItem);
            //await _context.SaveChangesAsync();

            
            await _todoItemRepository.Salvar(todoItem);

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/TodoItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            
            var todoItem = await _todoItemRepository.ListarPorId(id);
         
            if (todoItem == null)
            {
                return NotFound();
            }

            await _todoItemRepository.Excluir(id);

            return NoContent();
        }

        private bool TodoItemExists(int id)
        {
            return _todoItemRepository.ListarPorId(id) != null;
        }
    }
}
