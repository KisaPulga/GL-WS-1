using System;
using System.Resources;

namespace ConsoleBibliotheque
{
    class Livre
    {
        private ResourceManager rm;

        public string Titre { get; set; }
        public string Auteur { get; set; }
        public bool EstDisponible { get; set; } = true;
        public string NomEmprunteur { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }

        public Livre(string titre, string auteur, ResourceManager resourceManager)
        {
            Titre = titre;
            Auteur = auteur;
            rm = resourceManager;
        }


        public string GetEtatLivre()
        {
            if (EstDisponible)
            {
                return rm.GetString("BookAvailable");
            }
            else
            {
                return string.Format(rm.GetString("BookBorrowedBy"), NomEmprunteur, DateEmprunt.ToShortDateString());
            }
        }

        public override string ToString() => $"{Titre} - {Auteur} - {GetEtatLivre()}";
        
    }
}
