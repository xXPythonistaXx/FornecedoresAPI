using Microsoft.AspNetCore.Mvc;
using FornecedoresAPI.Models;
using FornecedoresAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FornecedoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly FornecedorService _fornecedorService;

        public FornecedoresController(FornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
            var result = await _fornecedorService.GetFornecedoresAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.ErrorMessage });
            }
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var result = await _fornecedorService.GetFornecedorAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.ErrorMessage });
            }
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            var result = await _fornecedorService.AddFornecedorAsync(fornecedor);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.ErrorMessage });
            }
            return CreatedAtAction(nameof(GetFornecedor), new { id = result.Value.Id }, result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest(new { Message = "ID do fornecedor não corresponde." });
            }

            var result = await _fornecedorService.UpdateFornecedorAsync(fornecedor);
            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.ErrorMessage });
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            var result = await _fornecedorService.DeleteFornecedorAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(new { Message = result.ErrorMessage });
            }
            return NoContent();
        }
    }
}
