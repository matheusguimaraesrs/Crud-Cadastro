using System.ComponentModel.DataAnnotations;

namespace Crud_Cadastro.Models;

public class ContatoModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }
    
    [Required(ErrorMessage =  "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email  invalido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Número de contato é obrigatório")]
    [Phone(ErrorMessage = "Contato invalido")]
    public string Contact { get; set; }
}
