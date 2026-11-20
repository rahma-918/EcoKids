namespace EcoKids.Models;

public static class CategorieDechetExtensions
{
    public static string Libelle(this CategorieDechet c) => c switch
    {
        CategorieDechet.Plastique => "Plastique",
        CategorieDechet.Papier => "Papier",
        CategorieDechet.Verre => "Verre",
        CategorieDechet.Organique => "Organique",
        CategorieDechet.Metal => "Métal",
        CategorieDechet.Textile => "Textile",
        _ => c.ToString()
    };

    public static string Icone(this CategorieDechet c) => c switch
    {
        CategorieDechet.Plastique => "♻️",
        CategorieDechet.Papier => "📄",
        CategorieDechet.Verre => "🍾",
        CategorieDechet.Organique => "🌱",
        CategorieDechet.Metal => "🔩",
        CategorieDechet.Textile => "👕",
        _ => "🗑️"
    };

    public static string CssClass(this CategorieDechet c) => c.ToString().ToLowerInvariant();
}