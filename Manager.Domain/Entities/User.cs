using Manager.Core.Exceptions;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities;

public class User : Base
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    
    //EF
    protected User(){}
    
    public User(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        _errors = new List<string>();
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
        Validate();
    }
    
    public void AtualizarSenha(string senha)
    {
        Senha = senha;

        Validate();
    }
    
    public void AtualizarEmail(string email)
    {
        Email = email;
        Validate();
    }

    public override bool Validate()
    {
        var validator = new UserValidator();
        var validation = validator.Validate(this);
        if (!validation.IsValid)
        {
            foreach (var errors in validation.Errors)
            {
                _errors.Add(errors.ErrorMessage);
            }
            throw new DomainException("Ta errado irmão vê isso aí", _errors);
           
        }

        return true;
    }
    
}