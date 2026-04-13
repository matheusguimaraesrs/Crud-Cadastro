using System.ComponentModel.DataAnnotations;

namespace Crud_Cadastro.Models;

public class ContatoModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo nome está vazio")]
    public string Name { get; set; }
    [Required(ErrorMessage =  "Campo email está vazio")]
    [EmailAddress(ErrorMessage = "Email  invalido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Campo número está vazio")]
    [Phone(ErrorMessage = "Contato invalido")]
    public string Contact { get; set; }
}
