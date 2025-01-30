namespace ConsoleBibliotheque
{
    /// <summary>
    /// Représente un livre, avec un titre, un auteur, sa disponibilité ainsi que le nom de l'emprunteur et la date d'emprunt.
    /// </summary>
    class Livre
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

        public override string ToString() => $"{Titre} - {Auteur} - {(EstDisponible ? "Disponible" : $"Emprunté par {NomEmprunteur} le {DateEmprunt}")}";

    }
}