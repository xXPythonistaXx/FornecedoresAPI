using FornecedoresAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FornecedoresAPI.Interfaces
{
    public interface IFornecedorService
    {
        Task<Result<List<Fornecedor>>> GetFornecedoresAsync();
        Task<Result<Fornecedor>> GetFornecedorAsync(int id);
        Task<Result<Fornecedor>> AddFornecedorAsync(Fornecedor fornecedor);
        Task<Result> UpdateFornecedorAsync(Fornecedor fornecedor);
        Task<Result> DeleteFornecedorAsync(int id);
    }
}
