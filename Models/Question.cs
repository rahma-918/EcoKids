namespace EcoKids.Models;

public class Question
{
    public int Id { get; init; }
    public string Enonce { get; init; } = "";
    public List<string> Choix { get; init; } = new();
    public int IndexBonneReponse { get; init; }
    public string Explication { get; init; } = "";
}