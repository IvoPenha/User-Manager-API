using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels;

public class UpdateViewModel
{

    [Required(ErrorMessage = "O id Não Pode ser vazio")]
    [Range(1, int.MaxValue, ErrorMessage = "O Id não pode ser menor que 1")]
    [DefaultValue(0)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome não pode ser vazio.")]
    [MinLength (3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
    [MaxLength (80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O email não pode ser vazio.")]
    [MinLength (3, ErrorMessage = "O email deve ter no mínimo 10 caracteres.")]
    [MaxLength (80, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
    [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
        ErrorMessage = "Email Invalido")]
    [DefaultValue("string")]
    public string Email { get; set; }  
    
    [Required(ErrorMessage = "A Senha não pode ser vazio.")]
    [MinLength (3, ErrorMessage = "A senha deve ter no mínimo 3 caracteres.")]
    [MaxLength (80, ErrorMessage = "A Senha deve ter no máximo 80 caracteres.")]
    public string Senha { get; set; }
}