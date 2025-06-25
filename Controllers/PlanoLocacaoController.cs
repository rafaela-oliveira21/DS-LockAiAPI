using Microsoft.AspNetCore.Mvc;
using LockAiAPI.Models;
using LockAiAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LockAiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropostaLocacaoController : ControllerBase
    {
        private readonly DataContext _context;

        public PropostaLocacaoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropostaLocacao>>> GetAll()
        {
            return await _context.PropostasLocacao.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropostaLocacao>> GetById(int id)
        {
            var proposta = await _context.PropostasLocacao.FindAsync(id);
            if (proposta == null)
                return NotFound();
            return proposta;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PropostaLocacao proposta)
        {
            _context.PropostasLocacao.Add(proposta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proposta.Id }, proposta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PropostaLocacao proposta)
        {
            if (id != proposta.Id)
                return BadRequest();

            _context.Entry(proposta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proposta = await _context.PropostasLocacao.FindAsync(id);
            if (proposta == null)
                return NotFound();

            _context.PropostasLocacao.Remove(proposta);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("confirmarPagamento")]
        public async Task<IActionResult> ConfirmarPagamento(int idProposta, int idUsuario)
        {
            var proposta = await _context.PropostasLocacao.FindAsync(idProposta);
            if (proposta == null) return NotFound();

            proposta.Situacao = 'P'; // Por exemplo: P = Pago
            proposta.DataSituacao = DateTime.UtcNow.ToString("yyyy-MM-dd");
            proposta.IdUsuarioSituacao = idUsuario;

            await _context.SaveChangesAsync();
            return Ok(proposta);
        }

        [HttpPost("cancelar")]
        public async Task<IActionResult> Cancelar(int idProposta)
        {
            var proposta = await _context.PropostasLocacao.FindAsync(idProposta);
            if (proposta == null) return NotFound();

            proposta.Situacao = 'C'; // C = Cancelado
            proposta.DataSituacao = DateTime.UtcNow.ToString("yyyy-MM-dd");

            await _context.SaveChangesAsync();
            return Ok(proposta);
        }
    }
}
