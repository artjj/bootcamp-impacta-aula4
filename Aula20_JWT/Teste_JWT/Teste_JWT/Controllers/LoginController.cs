using Teste_JWT.Dto;
using Teste_JWT.Models;
using Teste_JWT.Services;
using Teste_JWT.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Teste_JWTDbContext _context;

        public LoginController(Teste_JWTDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            try 
            { 
                if(string.IsNullOrEmpty(dto.Login) || string.IsNullOrWhiteSpace(dto.Login)
                    || string.IsNullOrEmpty(dto.Password) || string.IsNullOrWhiteSpace(dto.Password))
                {
                    return BadRequest("Parametros de entrada invalidos");
                }

                User user = await _context.User.FirstOrDefaultAsync(u => u.Email.ToLower() == dto.Login.Trim().ToLower()
                        || u.Password == PasswordUtil.GeneratePassword(dto.Password));

                if(user == null)
                {
                    return BadRequest("Parametros de entrada invalidos");
                }

                string token = TokenService.GenerateToken(user);
                return Ok(new {
                    Email = user.Email,
                    Token = token
                });
            }
            catch( Exception)
            {
                return BadRequest("Nao foi possivel autenticar, tente novamente");
            }
        }
    }
}
