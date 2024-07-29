using FornecedoresAPI.Interfaces;
using FornecedoresAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FornecedoresAPI.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<Result<List<Fornecedor>>> GetFornecedoresAsync()
        {
            var fornecedores = await _fornecedorRepository.GetFornecedoresAsync();
            return Result<List<Fornecedor>>.Success(fornecedores);
        }

        public async Task<Result<Fornecedor>> GetFornecedorAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorAsync(id);
            if (fornecedor == null)
            {
                return Result<Fornecedor>.Fail("Fornecedor não encontrado.");
            }
            return Result<Fornecedor>.Success(fornecedor);
        }

        public async Task<Result<Fornecedor>> AddFornecedorAsync(Fornecedor fornecedor)
        {
            await _fornecedorRepository.AddFornecedorAsync(fornecedor);
            return Result<Fornecedor>.Success(fornecedor);
        }

        public async Task<Result> UpdateFornecedorAsync(Fornecedor fornecedor)
        {
            var existingFornecedor = await _fornecedorRepository.GetFornecedorAsync(fornecedor.Id);
            if (existingFornecedor == null)
            {
                return Result.Fail("Fornecedor não encontrado.");
            }
            await _fornecedorRepository.UpdateFornecedorAsync(fornecedor);
            return Result.Success();
        }

        public async Task<Result> DeleteFornecedorAsync(int id)
        {
            var existingFornecedor = await _fornecedorRepository.GetFornecedorAsync(id);
            if (existingFornecedor == null)
            {
                return Result.Fail("Fornecedor não encontrado.");
            }
            await _fornecedorRepository.DeleteFornecedorAsync(id);
            return Result.Success();
        }
    }
}
