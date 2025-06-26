using Microsoft.AspNetCore.Mvc;
using LockAiAPI.Models;
using LockAiAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LockAiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanoLocacaoController : ControllerBase
    {
        private readonly DataContext _context;

        public PlanoLocacaoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanoLocacao>>> GetAll()
        {
            return await _context.PlanoLocacao.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanoLocacao>> GetById(int id)
        {
            var plano = await _context.PlanoLocacao.FindAsync(id);
            if (plano == null)
                return NotFound();
            return plano;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PlanoLocacao planoLocacao)
        {
            _context.PlanoLocacao.Add(planoLocacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = planoLocacao.Id }, planoLocacao);
        }

        [HttpPut("{id}")]
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
            var planolocacao = await _context.PlanoLocacao.FindAsync(id);
            if (planolocacao == null)
                return NotFound();

            _context.PlanoLocacao.Remove(planolocacao);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("confirmarPagamento")]
        public async Task<IActionResult> ConfirmarPagamento(int idPlanoLocacao, int idUsuario)
        {
            var planoLocacao = await _context.PlanoLocacao.FindAsync(idPlanoLocacao);
            if (planoLocacao == null) return NotFound();

            planoLocacao.Situacao = 'P'; // Por exemplo: P = Pago
            planoLocacao.DataSituacao = DateTime.UtcNow.ToString("yyyy-MM-dd");
            planoLocacao.IdUsuarioSituacao = idUsuario;

            await _context.SaveChangesAsync();
            return Ok(planoLocacao);
        }

        [HttpPost("cancelar")]
        public async Task<IActionResult> Cancelar(int idPlanoLocacao)
        {
            var planolocacao = await _context.PlanoLocacao.FindAsync(idPlanoLocacao);
            if (planolocacao == null) return NotFound();

            planolocacao.Situacao = 'C'; // C = Cancelado
            planolocacao.DataSituacao = DateTime.UtcNow.ToString("yyyy-MM-dd");

            await _context.SaveChangesAsync();
            return Ok(planolocacao);
        }
    }
}
