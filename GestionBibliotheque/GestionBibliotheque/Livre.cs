using System;

public class Livre
{
    public string Titre { get; set; }
    public string Auteur { get; set; }
    public bool EstDisponible { get; set; } = true;
    public string NomEmprunteur { get; set; }
    public DateTime DateEmprunt { get; set; }
    public DateTime DateRetour { get; set; }

    public Livre(string titre, string auteur)
    {
        Titre = titre;
        Auteur = auteur;
    }

    public override string ToString() => $"Le livre {Titre}, écrit par {Auteur} est {(EstDisponible ? "disponible." : $"emprunté par {NomEmprunteur} le {DateEmprunt}.")}";

    public void Emprunter(string nomEmprunteur)
    {
        DateEmprunt = DateTime.Now;
        DateRetour = DateTime.Now.AddDays(7);
        NomEmprunteur = nomEmprunteur;
        EstDisponible = false;
        Console.WriteLine($"Le livre {Titre} est emprunté du {DateEmprunt} au {DateRetour} par {NomEmprunteur}.\n");
    }
    public void Retourner()
    {
        NomEmprunteur = string.Empty;
        EstDisponible = true;
        if (DateTime.Now > DateRetour)
        {
            Console.WriteLine($"Le livre {Titre} a été rendu en retard de {DateTime.Now.Day - DateRetour.Day} jours.\n");
        }
        else
        {
            Console.WriteLine($"Le livre {Titre} a été rendu à l'heure.\n");
        }
    }
}