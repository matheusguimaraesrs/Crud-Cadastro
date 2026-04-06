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
    public IActionResult Index()
    {
        List<ContatoModel> contacts = _repository.AllContacts();
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
        _repository.Add(contato);
        return RedirectToAction("Index");
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
        _repository.Update(contato);
        return RedirectToAction("Index");
    }
    
    //Apagar
    public IActionResult Apagar(int id)
    {
        ContatoModel contato = _repository.ListForId(id);
        return View(contato);
    }

    public IActionResult ApagarSim(int id)
    {
        _repository.Delete(id);
        return RedirectToAction("Index");
    }
}