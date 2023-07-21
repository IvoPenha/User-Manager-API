namespace Manager.Services.DTO;

public class UserDTO
{
    public UserDTO(long id, string nome, string email, string senha)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
    }

    public UserDTO()
    {
        
    }

    public long Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}