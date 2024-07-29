using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FornecedoresAPI.Data;
using FornecedoresAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FornecedoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly FornecedoresContext _context;
        private readonly ILogger<FornecedoresController> _logger;

        public FornecedoresController(FornecedoresContext context, ILogger<FornecedoresController> logger)
        {
            _context = context;
            _logger = logger;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FindAsync(id);

                if (fornecedor == null)
                {
                    return NotFound(new { message = "Fornecedor não encontrado." });
                }

                return fornecedor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar fornecedor.");
                return StatusCode(500, new { message = "Erro interno do servidor." });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Erro ao adicionar fornecedor.");
                return StatusCode(500, new { message = "Erro ao adicionar fornecedor." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao adicionar fornecedor.");
                return StatusCode(500, new { message = "Erro interno do servidor." });
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
