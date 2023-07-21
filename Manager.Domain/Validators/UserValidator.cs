using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Não pode ser Vazio")
            .NotNull().WithMessage("Não Pode Ser Nulo");


        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Não pode ser Vazio")
            .NotNull().WithMessage("Não Pode Ser Nulo")
            .MinimumLength(3).WithMessage("O nome deve ter no minimo 3 caracteres")
            .MaximumLength(80).WithMessage("O nome deve ter no maximo 80 caracteres");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Não pode ser Vazio")
            .NotNull().WithMessage("Não Pode Ser Nulo")
            .MinimumLength(3).WithMessage("O Email deve ter no minimo 3 caracteres")
            .MaximumLength(80).WithMessage("O Email deve ter no maximo 100 caracteres")
            .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
            .WithMessage("Email invalido");
        
        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("A Senha não pode ser Vazia")
            .NotNull().WithMessage("A Senha não pode ser Vazia")
            .MinimumLength(3).WithMessage("A Senha deve ter no minimo 3 caracteres")
            .MaximumLength(80).WithMessage("A Senha deve ter no maximo 80 caracteres");
    }
    
}