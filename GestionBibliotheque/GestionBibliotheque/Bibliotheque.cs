using System;

public class Bibliotheque
{
    private List<Livre> maList = new List<Livre>();

    public void AfficherLivre()
    {
        if (maList.Count == 0)
        {
            Console.WriteLine("Aucun livre dans la bibliothèque.");
            return;
        }
        foreach (Livre livre in maList)
        {
            Console.WriteLine($"{livre.Titre} - {(livre.EstDisponible ? "Disponible" : $"Emprunté par {livre.NomEmprunteur} le {livre.DateEmprunt}")}");
        }
    }

    public void AjouterLivre(Livre livre)
    {
        maList.Add(livre);
        Console.WriteLine($"Le livre {livre.Titre} a bien été ajouté.");
    }

    public void SupprimerLivre(string titre)
    {
        Livre livre = RechercherLivre(titre);

        if (livre != null)
        {
            maList.Remove(livre);
            Console.WriteLine("Livre correctement supprimé.");
        }
        else
        {
            Console.WriteLine("Ce livre n'existe pas.");
        }

    }

    public Livre RechercherLivre(string titre)
    {
        foreach (Livre livre in maList)
        {
            if (livre.Titre == titre)
            {
                Console.WriteLine($"Livre trouvé : {livre.Titre}, Auteur : {livre.Auteur}");
                return livre;
            }
        }
        Console.WriteLine("Ce livre n'existe pas.");
        return null;
    }

    public void EmprunterLivre(string titre, string nomEmprunteur)
    {
        Livre livre = RechercherLivre(titre);

        if(livre == null)
        {
            return;
        }
        else if(livre.EstDisponible == true)
        {
            livre.Emprunter(nomEmprunteur);
        }
        else
        {
            Console.WriteLine("Ce livre n'existe pas.");
        }
    }

    public void RetournerLivre(string titre)
    {
        Livre livre = RechercherLivre(titre);

        if (livre != null && livre.EstDisponible)
        {
            livre.Retourner();
        }
        else
        {
            Console.WriteLine("Ce livre n'existe pas.");
        }
    }
}