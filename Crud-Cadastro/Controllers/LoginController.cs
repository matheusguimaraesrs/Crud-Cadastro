using Crud_Cadastro.DTOs;
using Crud_Cadastro.Models;
using Crud_Cadastro.Repositories.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Cadastro.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioRepository _repository;
    
    public LoginController(IUsuarioRepository repository)
    {
        _repository =  repository;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Entrar(LoginRequest loginRequest)
    {
        try
        {
            if (ModelState.IsValid)
            {
                UsuarioModel? usuario = _repository.GetByLogin(loginRequest.Login);
                if (usuario != null && usuario.ValidatePassword(loginRequest.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData[$"MensagemErro"] = $"Usuário e/ou senha incorretos! :(";
        }
        catch (Exception e)
        {
            TempData[$"MensagemErro"] = $"Ops! Ocorreu um erro :(\nError: {e.Message}";
        }
        return View("Index");
    }
}

