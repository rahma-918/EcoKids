using EcoKids.Models;
using EcoKids.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoKids.Controllers;

public class TriController : Controller
{
    private readonly ITriService _triService;

    public TriController(ITriService triService) => _triService = triService;

    public IActionResult Index() => View(_triService.ProchainDechet());

    [HttpPost]
    public IActionResult Trier(int dechetId, CategorieDechet choix)
    {
        var resultat = _triService.Trier(dechetId, choix);
        return View("Resultat", resultat);
    }
}