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
}