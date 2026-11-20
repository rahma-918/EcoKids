using EcoKids.Models;

namespace EcoKids.Services;

public interface ITriService
{
    Dechet ProchainDechet();
    ResultatTri Trier(int dechetId, CategorieDechet choix);
}

public class TriService : ITriService
{
    private readonly List<Dechet> _dechets = new()
    {
        new() { Id = 1, Nom = "Bouteille d'eau",  Emoji = "🍼", CategorieCorrecte = CategorieDechet.Plastique },
        new() { Id = 2, Nom = "Journal",          Emoji = "📰", CategorieCorrecte = CategorieDechet.Papier },
        new() { Id = 3, Nom = "Bocal en verre",   Emoji = "🫙", CategorieCorrecte = CategorieDechet.Verre },
        new() { Id = 4, Nom = "Peau de banane",   Emoji = "🍌", CategorieCorrecte = CategorieDechet.Organique },
        new() { Id = 5, Nom = "Canette",          Emoji = "🥫", CategorieCorrecte = CategorieDechet.Metal },
        new() { Id = 6, Nom = "Carton de pizza",  Emoji = "📦", CategorieCorrecte = CategorieDechet.Papier },
        new() { Id = 7, Nom = "Sachet plastique", Emoji = "🛍️", CategorieCorrecte = CategorieDechet.Plastique },
        new() { Id = 8, Nom = "Épluchures",       Emoji = "🥕", CategorieCorrecte = CategorieDechet.Organique },
        new() { Id = 9,  Nom = "Vieux t-shirt",   Emoji = "👕", CategorieCorrecte = CategorieDechet.Textile },
        new() { Id = 10, Nom = "Chaussette",      Emoji = "🧦", CategorieCorrecte = CategorieDechet.Textile },
    };

    public Dechet ProchainDechet() => _dechets[Random.Shared.Next(_dechets.Count)];

    public ResultatTri Trier(int dechetId, CategorieDechet choix)
    {
        var dechet = _dechets.First(d => d.Id == dechetId);
        bool ok = dechet.CategorieCorrecte == choix;

        return new ResultatTri
        {
            Dechet = dechet,
            ChoixJoueur = choix,
            EstCorrect = ok,
            PointsGagnes = ok ? 10 : 0,
            Message = ok
               ? "Bravo ! Tu protèges la planète 🌍"
               : "Oups, ce n'est pas la bonne poubelle !"
        };
    }
}