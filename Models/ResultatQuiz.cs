namespace EcoKids.Models;

public class CorrectionQuestion
{
    public Question Question { get; init; } = null!;
    public int IndexChoisi { get; init; }   // -1 si pas de réponse
    public bool EstCorrecte { get; init; }
}

public class ResultatQuiz
{
    public List<CorrectionQuestion> Corrections { get; init; } = new();
    public int Score => Corrections.Count(c => c.EstCorrecte);
    public int Total => Corrections.Count;
    public int PointsGagnes => Score * 10;

    public string Message => Score switch
    {
        _ when Score == Total => "Parfait ! Tu es un vrai écologiste ",
        _ when Score >= Total / 2.0 => "Bien joué ! Continue comme ça ",
        _ => "Pas de souci, tu vas apprendre en rejouant "
    };
}