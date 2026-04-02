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
    public IActionResult Editar()
    {
        return View();
    }
    
    //Apagar
    public IActionResult Apagar()
    {
        return View();
    }
}