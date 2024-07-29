using Microsoft.AspNetCore.Mvc;
using FornecedoresAPI.Models;
using FornecedoresAPI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FornecedoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController(IFornecedorService fornecedorService)
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

            if (result.Value == null)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
            return CreatedAtAction(nameof(GetFornecedor), new { id = result.Value.Id }, result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> PutFornecedor(Fornecedor fornecedor)
        {
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
