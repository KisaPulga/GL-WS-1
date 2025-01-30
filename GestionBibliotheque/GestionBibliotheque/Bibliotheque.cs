using System;
using System.Collections.Generic;
using System.Resources;

namespace ConsoleBibliotheque
{
    class Bibliotheque
    {
        private List<Livre> maList = new List<Livre>();
        private ResourceManager rm;

        public Bibliotheque(ResourceManager resourceManager)
        {
            rm = resourceManager; 
        }

        public void AjouterLivre(Livre livre)
        {
            maList.Add(livre);
            Console.WriteLine(rm.GetString("BookAdded") + livre.Titre); 
        }

        public Livre RechercherLivre(string titre)
        {
            foreach (Livre livre in maList)
            {
                if (livre.Titre == titre)
                {
                    Console.WriteLine(rm.GetString("BookFound") + livre.Titre + "- " + rm.GetString("Author") + ": " + livre.Auteur); 
                    return livre;
                }
                else
                {
                    Console.WriteLine(rm.GetString("BookNotFound") + titre);
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
                Console.WriteLine(rm.GetString("BookDeleted") + livre.Titre);
            }
        }

        public void AfficherLivre()
        {    
            if (maList.Count == 0)
            {
                Console.WriteLine(rm.GetString("NoBooksInLibrary")); 
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
                Console.WriteLine(rm.GetString("BookBorrowed") + livre.Titre + " " + rm.GetString("By") + " " + livre.NomEmprunteur); 
            }
            else if (livre != null)
            {
                Console.WriteLine(rm.GetString("BookAlreadyBorrowed") + livre.Titre); 
            }
        }

        public void RetournerLivre(string titre)
        {
            Livre livre = RechercherLivre(titre);
            if (livre != null && !livre.EstDisponible)
            {
                Console.WriteLine(DateTime.Now > livre.DateRetour
                    ? rm.GetString("BookReturnedLate") + livre.Titre 
                    : rm.GetString("BookReturnedOnTime") + livre.Titre); 

                livre.NomEmprunteur = null;
                livre.EstDisponible = true;
                livre.DateEmprunt = DateTime.MinValue;
                livre.DateRetour = DateTime.MinValue;
            }
            else if (livre != null)
            {
                Console.WriteLine(rm.GetString("BookNotBorrowed") + livre.Titre);
            }
        }
    }
}
