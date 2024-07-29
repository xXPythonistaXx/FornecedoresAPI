using FluentValidation;
using FornecedoresAPI.Models;

namespace FornecedoresAPI.Validations
{
    public class FornecedorValidator : AbstractValidator<Fornecedor>
    {
        public FornecedorValidator()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ser válido.");
        }
    }
}
