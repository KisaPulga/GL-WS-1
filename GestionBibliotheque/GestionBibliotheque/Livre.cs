using System;

public class Livre
{
    private string Titre;
    private string Auteur;
    private bool EstDisponible = true;
    private string NomEmprunteur;
    private DateTime DateEmprunt;
    private DateTime DateRetour;

    public Livre(string titre, string auteur)
    {
        Titre = titre;
        Auteur = auteur;
    }

    public override string ToString() => $"Le livre {Titre}, écrit par {Auteur} est {(EstDisponible ? "disponible" : $"emprunté par {NomEmprunteur}")}";
}