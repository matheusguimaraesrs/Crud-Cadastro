using Crud_Cadastro.Models;
using Crud_Cadastro.Repositories.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Cadastro.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuarioRepository _repository;
    public UsuarioController(IUsuarioRepository repository)
    {
        _repository = repository;
    }
    // GET
    public IActionResult Index(int currentPage = 1, int pageSize = 10)
    {
        int allUsers = _repository.AllUsers();
        List<UsuarioModel> users = _repository.PageUsers(currentPage, pageSize);
        ViewBag.CurrentPage = currentPage;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalPages = (int)Math.Ceiling((double)allUsers / pageSize);
        return View(users);
    }
    
    //Criar
    public IActionResult Criar()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _repository.Add(usuario);
                TempData["MensagemSucesso"] = "Contato criado com sucesso!";
                return RedirectToAction("Index");
            }
        }
        catch (Exception e)
        {
            TempData[$"MensagemErro"] = $"Ops! Ocorreu um erro :(\nError: {e.Message}";
            return RedirectToAction("Index");
        }        
        
        return View(usuario);
    }
    
    //Editar
    public IActionResult Editar(int id)
    {
        UsuarioModel usuario = _repository.ListForId(id);
        return View(usuario);
    }
    [HttpPost]
    public IActionResult Editar(UsuarioModel usuario)
    {
        try
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                _repository.Update(usuario);
                TempData["MensagemSucesso"] = "Usuário criado com sucesso!";
                return RedirectToAction("Index");
            }
        }
        catch (Exception e)
        {
            TempData[$"MensagemErro"] = $"Ops! Ocorreu um erro :(\nError: {e.Message}";
            return RedirectToAction("Index");
        }
        
        return View(usuario);
    }
    
    //Apagar
    public IActionResult Apagar(int id)
    {
        UsuarioModel usuario = _repository.ListForId(id);
        return View(usuario);
    }
    public IActionResult ApagarSim(int id)
    {
        try
        {
            bool deleted = _repository.Delete(id);
            if (deleted)
            {
                TempData[$"MensagemSucesso"] = $"Usuário  apagado  com sucesso!";
            }
            else
            {
                TempData[$"MensagemErro"] = $"Ops! Ocorreu um erro";
            }
        }
        catch (Exception e)
        {
            TempData[$"MensagemErro"] = $"Ops! Ocorreu um erro :(\nError: {e.Message}";
        }
        return RedirectToAction("Index");
    }
}

