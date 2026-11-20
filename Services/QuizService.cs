using EcoKids.Models;

namespace EcoKids.Services;

public interface IQuizService
{
    List<Question> TirerQuestions(int nombre);
    ResultatQuiz Corriger(IEnumerable<int> questionIds, Dictionary<int, int> reponses);
}

public class QuizService : IQuizService
{
    private readonly List<Question> _questions = new()
    {
        new() { Id = 1, Enonce = "Combien de temps une bouteille en plastique met-elle à disparaître dans la nature ?",
                Choix = new() { "Quelques jours", "Quelques mois", "Des centaines d'années" },
                IndexBonneReponse = 2,
                Explication = "Le plastique se décompose extrêmement lentement. C'est pour ça qu'il faut le trier !" },

        new() { Id = 2, Enonce = "Quand faut-il fermer le robinet ?",
                Choix = new() { "Pendant que je me brosse les dents", "Jamais", "Seulement le soir" },
                IndexBonneReponse = 0,
                Explication = "Laisser couler l'eau pendant le brossage gaspille plusieurs litres pour rien." },

        new() { Id = 3, Enonce = "Quelle énergie vient du soleil ?",
                Choix = new() { "L'énergie nucléaire", "L'énergie solaire", "L'énergie du charbon" },
                IndexBonneReponse = 1,
                Explication = "L'énergie solaire est propre et renouvelable." },

        new() { Id = 4, Enonce = "Que fais-tu en quittant une pièce ?",
                Choix = new() { "Je laisse la lumière allumée", "J'éteins la lumière", "J'allume la télé" },
                IndexBonneReponse = 1,
                Explication = "Éteindre la lumière économise de l'énergie." },

        new() { Id = 5, Enonce = "Que veut dire « recycler » ?",
                Choix = new() { "Jeter par terre", "Brûler les déchets", "Transformer les déchets pour fabriquer de nouveaux objets" },
                IndexBonneReponse = 2,
                Explication = "Recycler, c'est donner une deuxième vie aux déchets." },

        new() { Id = 6, Enonce = "Quel moyen de transport pollue le moins ?",
                Choix = new() { "La voiture", "Le vélo ou la marche", "L'avion" },
                IndexBonneReponse = 1,
                Explication = "Marcher ou pédaler ne rejette aucune fumée polluante." },

        new() { Id = 7, Enonce = "Quel animal est en danger à cause des sacs plastiques dans la mer ?",
                Choix = new() { "La tortue marine", "Le chameau", "Le lion" },
                IndexBonneReponse = 0,
                Explication = "Les tortues confondent les sacs avec des méduses et les mangent." },

        new() { Id = 8, Enonce = "Que fais-tu d'une bouteille vide ?",
                Choix = new() { "Je la jette dans la nature", "Je la mets dans la bonne poubelle de tri", "Je l'enterre dans le jardin" },
                IndexBonneReponse = 1,
                Explication = "Bien triée, elle pourra être recyclée." },

        new() { Id = 9, Enonce = "Qu'est-ce qui consomme le moins d'eau ?",
                Choix = new() { "Une douche courte", "Un long bain", "C'est pareil" },
                IndexBonneReponse = 0,
                Explication = "Un bain demande beaucoup plus d'eau qu'une douche rapide." },

        new() { Id = 10, Enonce = "À quoi servent les arbres ?",
                Choix = new() { "À produire du plastique", "À produire de l'oxygène", "À produire de la fumée" },
                IndexBonneReponse = 1,
                Explication = "Les arbres absorbent le CO₂ et rejettent de l'oxygène." },
    };

    public List<Question> TirerQuestions(int nombre) =>
        _questions.OrderBy(_ => Random.Shared.Next()).Take(nombre).ToList();

    public ResultatQuiz Corriger(IEnumerable<int> questionIds, Dictionary<int, int> reponses)
    {
        var corrections = new List<CorrectionQuestion>();

        foreach (var id in questionIds)
        {
            var question = _questions.First(q => q.Id == id);
            int choisi = reponses.TryGetValue(id, out var r) ? r : -1;

            corrections.Add(new CorrectionQuestion
            {
                Question = question,
                IndexChoisi = choisi,
                EstCorrecte = choisi == question.IndexBonneReponse
            });
        }

        return new ResultatQuiz { Corrections = corrections };
    }
}