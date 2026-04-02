using Microsoft.AspNetCore.Mvc;

namespace Crud_Cadastro.Controllers;

public class ContatoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Criar()
    {
        return View();
    }
    public IActionResult Editar()
    {
        return View();
    }
    public IActionResult Apagar()
    {
        return View();
    }
}