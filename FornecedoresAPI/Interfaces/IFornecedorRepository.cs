using FornecedoresAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FornecedoresAPI.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<List<Fornecedor>> GetFornecedoresAsync();
        Task<Fornecedor> GetFornecedorAsync(int id);
        Task AddFornecedorAsync(Fornecedor fornecedor);
        Task UpdateFornecedorAsync(Fornecedor fornecedor);
        Task DeleteFornecedorAsync(int id);
    }
}
