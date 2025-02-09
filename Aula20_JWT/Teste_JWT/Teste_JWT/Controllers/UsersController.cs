﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_JWT.Dto;
using Teste_JWT.Models;
using Teste_JWT.Utils;

namespace Teste_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Teste_JWTDbContext _context;

        public UsersController(Teste_JWTDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> PutUser(int id, SalvarUsuarioDto dto)
        {
            User user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return BadRequest("Usuario nao encontrado");
            }

            user.Name = dto.Name;
            user.Profile = dto.Profile;
            user.Email = dto.Email;
            user.Password = PasswordUtil.GeneratePassword(dto.Password);

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> CadastroPublico(SalvarUsuarioDto dto)
        {
            if (string.IsNullOrEmpty(dto.Password) || string.IsNullOrWhiteSpace(dto.Password))
            {
                return BadRequest("Favor informar todos os dados");
            }

            User usuario = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = PasswordUtil.GeneratePassword(dto.Password),
                Profile = "USER"
            };

            _context.User.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CadastroPublico", new { id = usuario.Id }, usuario);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(SalvarUsuarioDto dto)
        {
            string idUsuarioLogged = User.Claims.Where(e => e.Type == ClaimTypes.Sid).Select(e => e.Value).FirstOrDefault();

            User logged = null;
            if (!string.IsNullOrEmpty(idUsuarioLogged))
            {
                logged = await _context.User.FirstOrDefaultAsync(u => u.Id == int.Parse(idUsuarioLogged));
            }

            if (string.IsNullOrEmpty(dto.Password) || string.IsNullOrWhiteSpace(dto.Password))
            {
                return BadRequest("Favor informar todos os dados!");
            }

            User user = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = PasswordUtil.GeneratePassword(dto.Password)
            };

            if (logged != null && logged.Profile == "ADMIN")
            {
                user.Profile = dto.Profile;
            }
            else
            {
                user.Profile = "USER";
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
