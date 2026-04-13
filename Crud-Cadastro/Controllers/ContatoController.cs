using Crud_Cadastro.Models;
using Crud_Cadastro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Cadastro.Controllers;

public class ContatoController : Controller
{
    private readonly IContatoRepository _repository;
    public ContatoController(IContatoRepository repository)
    {
        _repository = repository;
    }
    
    //Index
    public IActionResult Index(int currentPage = 1, int pageSize = 10)
    {
        int allContacts = _repository.AllContacts();
        List<ContatoModel> contacts = _repository.PageContacts(currentPage, pageSize);
        ViewBag.CurrentPage = currentPage;
        ViewBag.TotalPages = (int)Math.Ceiling((double)allContacts / pageSize);
        return View(contacts);
    }
    
    //Criar
    public IActionResult Criar()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _repository.Add(contato);
                TempData["MensagemSucesso"] = "Contato criado com sucesso!";
                return RedirectToAction("Index");
            }
        }
        catch (Exception e)
        {
            TempData[$"MensagemErro"] = $"Ops! Ocorreu um erro :(\nError: {e.Message}";
            return RedirectToAction("Index");
        }        
        
        return View(contato);
    }
    
    //Editar
    public IActionResult Editar(int id)
    {
        ContatoModel contato = _repository.ListForId(id);
        return View(contato);
    }
    [HttpPost]
    public IActionResult Editar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _repository.Update(contato);
                TempData["MensagemSucesso"] = "Contato criado com sucesso!";
                return RedirectToAction("Index");
            }
        }
        catch (Exception e)
        {
            TempData[$"MensagemErro"] = $"Ops! Ocorreu um erro :(\nError: {e.Message}";
            return RedirectToAction("Index");
        }
        
        return View(contato);
    }
    
    //Apagar
    public IActionResult Apagar(int id)
    {
        ContatoModel contato = _repository.ListForId(id);
        return View(contato);
    }

    public IActionResult ApagarSim(int id)
    {
        try
        {
            bool deleted = _repository.Delete(id);
            if (deleted)
            {
                TempData[$"MensagemSucesso"] = $"Contato apagado  com sucesso!";
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