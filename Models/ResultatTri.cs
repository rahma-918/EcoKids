namespace EcoKids.Models;

public class ResultatTri
{
    public Dechet Dechet { get; init; } = null!;
    public CategorieDechet ChoixJoueur { get; init; }
    public bool EstCorrect { get; init; }
    public int PointsGagnes { get; init; }
    public string Message { get; init; } = "";
}