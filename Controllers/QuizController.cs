using EcoKids.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoKids.Controllers;

public class QuizController : Controller
{
    private const int NombreQuestions = 5;
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService) => _quizService = quizService;

    public IActionResult Index() => View(_quizService.TirerQuestions(NombreQuestions));

    [HttpPost]
    public IActionResult Corriger(int[] questionIds, Dictionary<int, int> reponses)
    {
        var resultat = _quizService.Corriger(questionIds, reponses ?? new());
        return View("Resultat", resultat);
    }
}