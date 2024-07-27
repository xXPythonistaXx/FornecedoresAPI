using Microsoft.EntityFrameworkCore;
using FornecedoresAPI.Models;

namespace FornecedoresAPI.Data
{
    public class FornecedoresContext : DbContext
    {
        public FornecedoresContext(DbContextOptions<FornecedoresContext> options)
            : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
