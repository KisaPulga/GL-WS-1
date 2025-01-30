namespace ConsoleBibliotheque
{
    class Bibliotheque
    {
        private List<Livre> maList = new List<Livre>();

        public void AjouterLivre(Livre livre)
        {
            maList.Add(livre);
            Console.WriteLine($"Le livre {livre.Titre} a correctement été ajouté.");
        }

        public Livre RechercherLivre(string titre)
        {
            foreach (Livre livre in maList)
            {
                if (livre.Titre == titre)
                {
                    Console.WriteLine($"Livre trouvé : {livre.Titre}, Auteur : {livre.Auteur}.");
                    return livre;
                }
                else
                {
                    Console.WriteLine($"Le livre {titre} n'existe pas.");

                }
            }
            return null;

        }

        public void SupprimerLivre(string titre)
        {
            Livre livre = RechercherLivre(titre);
            if (livre != null)
            {
                maList.Remove(livre);
                Console.WriteLine($"Le livre {livre.Titre} a bien été supprimé.");
            }
        }

        public void AfficherLivre()
        {
            if (maList.Count == 0)
            {
                Console.WriteLine("Aucun livre présent dans la bibliothèque");
            }
            else
            {
                foreach (Livre livre in maList)
                {
                    Console.WriteLine(livre);
                }
            }
        }

        public void EmprunterLivre(string titre, string nomEmprunteur)
        {
            Livre livre = RechercherLivre(titre);
            if (livre != null && livre.EstDisponible)
            {
                livre.NomEmprunteur = nomEmprunteur;
                livre.EstDisponible = false;
                livre.DateEmprunt = DateTime.Now;
                livre.DateRetour = DateTime.Now.AddDays(7);
                Console.WriteLine($"Le livre {livre.Titre} a été emprunté par {nomEmprunteur}.");
            }
            else if (livre != null)
            {
                Console.WriteLine($"Le livre {livre.Titre} est déjà emprunté.");
            }
        }

        public void RetournerLivre(string titre)
        {
            Livre livre = RechercherLivre(titre);
            if (livre != null && !livre.EstDisponible)
            {
                Console.WriteLine(DateTime.Now > livre.DateRetour
                    ? $"Le livre {livre.Titre} a été rendu en retard."
                    : $"Le livre {livre.Titre} a été rendu à temps.");

                livre.NomEmprunteur = null;
                livre.EstDisponible = true;
                livre.DateEmprunt = DateTime.MinValue;
                livre.DateRetour = DateTime.MinValue;
            }
            else if (livre != null)
            {
                Console.WriteLine($"Le livre {livre.Titre} n'est pas emprunté.");
            }
        }
    }
}