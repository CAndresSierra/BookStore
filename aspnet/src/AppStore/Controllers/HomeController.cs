using AppStore.Models.Domain;
using AppStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace AppStore.Controllers;

public class HomeController : Controller
{

    private readonly ILibroService _libroService;

    public HomeController(ILibroService libroService)
    {
        _libroService = libroService;
    }

    public IActionResult Index(string term="", int currentPage = 1)
    {
        var libros = _libroService.List(term, true, currentPage);

        return View(libros);
    }

    public IActionResult LibroDetail(int libroId) 
    {
       Libro libro =  _libroService.GetById(libroId);

       return View(libro);
    }

    public IActionResult About()
    {
        return View();
    }
}
