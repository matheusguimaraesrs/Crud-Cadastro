using System.ComponentModel.DataAnnotations;

namespace Crud_Cadastro.DTOs;

public record LoginRequest(
    [Required(ErrorMessage = "Login é obrigatório")]
    string Login, 
    [Required(ErrorMessage = "Senha é obrigatória")]
    string Password);