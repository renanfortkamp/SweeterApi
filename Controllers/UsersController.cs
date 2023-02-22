using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sweeter.Context;
using Sweeter.Models.Dto;
using Sweeter.Models.Entities;

namespace Sweeter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SweeterContext _context;

        public UsersController(SweeterContext context)
        {
            _context = context;
        }

        // GET: api/Users?email={email}&password={password}
        [HttpGet("{email}&{password}")]
        public async Task<ActionResult<User>> GetUser(string email, string password)
        {
            try
            {
                var user = await _context.users
                    .Where(u => u.Email == email && u.Password == password)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound("Usuário não localizado");
                }

                return user;
            }
            catch
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto userDto)
        {
            try
            {
                var userExist = await _context.users
                    .Where(u => u.Email == userDto.Email)
                    .FirstOrDefaultAsync();
                if (userExist != null)
                {
                    return BadRequest("Email já cadastrado");
                }

                var user = new User
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password
                };
                _context.users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
