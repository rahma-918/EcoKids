namespace EcoKids.Models;

public class Dechet
{
    public int Id { get; init; }
    public string Nom { get; init; } = "";
    public string Emoji { get; init; } = "";
    public CategorieDechet CategorieCorrecte { get; init; }
}