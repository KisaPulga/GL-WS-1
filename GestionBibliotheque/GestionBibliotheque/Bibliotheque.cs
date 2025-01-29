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
            Console.WriteLine($"{livre.Titre} - {(livre.EstDisponible ? "Disponible" : $"Emprunté par {livre.NomEmprunteur}")}");
        }
    }

    public void AjouterLivre(Livre livre)
    {
        maList.Add(livre);
        Console.WriteLine($"Le livre {livre.Titre} a bien été ajouté.");
    }

    public void SupprimerLivre(string titre)
    {
        foreach(Livre livre in maList)
        {
            if(livre.Titre == titre)
            {
                maList.Remove(livre);
                Console.WriteLine($"Le livre {titre} a été supprimé.");
                return;
            }
        }
        Console.WriteLine($"Le livre {titre} n'existe pas.");
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
        bool livreTrouve = false;

        foreach (Livre livre in maList)
        {
            if (livre.Titre == titre)
            {
                if (livre.EstDisponible)
                {
                    livre.EstDisponible = false;
                    livre.NomEmprunteur = nomEmprunteur;
                    livre.DateEmprunt = DateTime.Now;
                    livre.DateRetour = DateTime.MinValue;
                    Console.WriteLine($"Le livre {titre} a été emprunté par {nomEmprunteur}.");
                }
                else
                {
                    Console.WriteLine($"Le livre {titre} est déjà emprunté par {livre.NomEmprunteur}.");
                }
                livreTrouve = true;
                break;
            }
        }
        if (!livreTrouve)
        {
            Console.WriteLine("Ce livre n'existe pas.");
        }
    }

    public void RetournerLivre(string titre)
    {
        bool livreTrouve = false;

        foreach (Livre livre in maList)
        {
            if (livre.Titre == titre)
            {
                livre.EstDisponible = true;
                livre.DateRetour = DateTime.Now;
                livre.NomEmprunteur = null;
                livreTrouve = true;
                Console.WriteLine($"Le livre {titre} a été retourné.");
                break;
            }
        }
        if (!livreTrouve)
        {
            Console.WriteLine("Ce livre n'existe pas.");
        }
    }
}