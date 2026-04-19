using System.ComponentModel.DataAnnotations;
using Crud_Cadastro.Enums;

namespace Crud_Cadastro.Models;

public class UsuarioModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Login é obrigatório")]
    public string Login { get; set; }
    
    [Required(ErrorMessage =  "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email  invalido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Senha é obrigatória")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Perfil é obrigatório")]
    public ProfileEnum? Profile { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
