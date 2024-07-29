using FornecedoresAPI.Data;
using FornecedoresAPI.Interfaces;
using FornecedoresAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FornecedoresAPI.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly FornecedoresContext _context;

        public FornecedorRepository(FornecedoresContext context)
        {
            _context = context;
        }

        public async Task<List<Fornecedor>> GetFornecedoresAsync()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task<Fornecedor?> GetFornecedorAsync(int id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task AddFornecedorAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFornecedorAsync(Fornecedor fornecedor)
        {
            var existingFornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(f => f.Id == fornecedor.Id);

            if (existingFornecedor == null)
            {
                throw new KeyNotFoundException("Fornecedor não encontrado.");
            }

            _context.Entry(existingFornecedor).CurrentValues.SetValues(fornecedor);

            var entry = _context.Entry(existingFornecedor);

            await _context.SaveChangesAsync();

        }



        public async Task DeleteFornecedorAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
