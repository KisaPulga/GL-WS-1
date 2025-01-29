using System;

public class Bibliotheque
{
    private List<Livre> maList = new List<Livre>();

    public void AfficherLivre()
    {
        foreach(Livre livre in maList)
        {
            Console.WriteLine(livre.Titre);
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
}