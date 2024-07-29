using FornecedoresAPI.Data;
using FornecedoresAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FornecedoresAPI.Services
{
    public class FornecedorService
    {
        private readonly FornecedoresContext _context;

        public FornecedorService(FornecedoresContext context)
        {
            _context = context;
        }

        public async Task<Result<List<Fornecedor>>> GetFornecedoresAsync()
        {
            var fornecedores = await _context.Fornecedores.ToListAsync();
            return Result<List<Fornecedor>>.Success(fornecedores);
        }

        public async Task<Result<Fornecedor>> GetFornecedorAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return Result<Fornecedor>.Failure("Fornecedor não encontrado.");
            }
            return Result<Fornecedor>.Success(fornecedor);
        }

        public async Task<Result<Fornecedor>> AddFornecedorAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            return Result<Fornecedor>.Success(fornecedor);
        }

        public async Task<Result> UpdateFornecedorAsync(Fornecedor fornecedor)
        {
            if (!await _context.Fornecedores.AnyAsync(f => f.Id == fornecedor.Id))
            {
                return Result.Failure("Fornecedor não encontrado.");
            }

            _context.Entry(fornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> DeleteFornecedorAsync(int id)
        {
            var fornecedorResult = await GetFornecedorAsync(id);
            if (!fornecedorResult.IsSuccess)
            {
                return Result.Failure(fornecedorResult.ErrorMessage);
            }

            _context.Fornecedores.Remove(fornecedorResult.Value);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
