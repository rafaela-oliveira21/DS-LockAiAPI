using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LockAiAPI.Models;
using LockAiAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace LockAiAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanoLocacaoController : ControllerBase
    {
        private readonly DataContext _context;

        public PlanoLocacaoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlanoLocacao>> GetById(int id)
        {
            var plano = await _context.TB_PLANO_LOCACAO.FindAsync(id);
            if (plano == null)
                return NotFound();
            return plano;
        }

        [HttpGet ("{GetAll}")]
        public async Task<ActionResult<IEnumerable<PlanoLocacao>>> GetAll()
        {
            return await _context.TB_PLANO_LOCACAO.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PlanoLocacao planoLocacao)
        {
            _context.TB_PLANO_LOCACAO.Add(planoLocacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = planoLocacao.Id }, planoLocacao);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, PlanoLocacao planoLocacao)
        {
            if (id != planoLocacao.Id)
                return BadRequest();

            _context.Entry(planoLocacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var planolocacao = await _context.TB_PLANO_LOCACAO.FindAsync(id);
            if (planolocacao == null)
                return NotFound();

            _context.TB_PLANO_LOCACAO.Remove(planolocacao);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
