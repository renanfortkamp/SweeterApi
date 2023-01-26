using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sweeter.Context;
using Sweeter.Models.Dto;
using Sweeter.Models.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Sweeter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SweetsController : ControllerBase
    {
        private readonly SweeterContext _context;
        private readonly IMapper _mapper;


        public SweetsController(SweeterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Sweets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sweet>>> Getsweets()
        {
            var sweet = await _context.sweets.ToListAsync();
            var sweetResponse = _mapper.Map<List<SweetAllDto>>(sweet);

            return Ok(sweetResponse);
        }

        // GET: api/Sweets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sweet>> GetSweet(int id,int userId)
        {
            var sweet = await _context.sweets.Where(u => u.Id == id && u.UserId == userId).FirstOrDefaultAsync();

            if (sweet == null)
            {
                return NotFound("Sweet não localizado");
            }

            return sweet;
        }

        // PUT: api/Sweets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSweet(int id, int userId,[FromBody] Sweet sweet)
        {

            if (id != sweet.Id || userId != sweet.UserId)
            {
                return BadRequest("Você tem que passar o id correto");//retirar com atualização da dto
            }
            var existSweet = await _context.sweets.FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);
            if (existSweet == null)
            {
                return BadRequest("Sweet não encontrado");
            }

            _context.Entry(sweet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SweetExists(id))
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

        // POST: api/Sweets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SweetDto>> PostSweet(int userId, SweetDto sweetDto )
        {
            var existUser =  await _context.users.FirstOrDefaultAsync(s => s.Id == userId);
            if (existUser == null)
            {
                return BadRequest("Usuario não encontrado");
            }

                Sweet sweet = new();
                sweet.Text = sweetDto.Text;                
                sweet.UserId = userId;
                _context.sweets.Add(sweet);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSweet", new { id = sweet.Id }, sweet);
            }

        // DELETE: api/Sweets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSweet(int id)
        {
            var sweet = await _context.sweets.FindAsync(id);
            if (sweet == null)
            {
                return NotFound();
            }

            _context.sweets.Remove(sweet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SweetExists(int id)
        {
            return _context.sweets.Any(e => e.Id == id);
        }
    }
}
