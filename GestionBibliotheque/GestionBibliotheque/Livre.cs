using System;

public class Livre
{
    public string Titre { get; set; }
    public string Auteur { get; set; }
    private bool EstDisponible { get; set; } = true;
    private string NomEmprunteur { get; set; }
    private DateTime DateEmprunt { get; set; }
    private DateTime DateRetour { get; set; }

    public Livre(string titre, string auteur)
    {
        Titre = titre;
        Auteur = auteur;
    }

    public override string ToString() => $"Le livre {Titre}, écrit par {Auteur} est {(EstDisponible ? "disponible." : $"emprunté par {NomEmprunteur} le {DateEmprunt}.")}";
}