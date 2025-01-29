using System;



class Program

{
    static void Main(string[] args)
    {
        // Création d'un objet Livre
        Livre livreTest = new Livre("The Dark Forest", "Cixin Liu");

        // Affichage des informations du livre en utilisant la méthode ToString()
        Console.WriteLine(livreTest.ToString());


        Bibliotheque bibliotheque = new Bibliotheque();

        // Test de la méthode AjouterLivre
        bibliotheque.AjouterLivre(new Livre("The Dark Forest", "Cixin Liu"));
        bibliotheque.AjouterLivre(new Livre("Peste", "Chuck Palahniuk"));

        bibliotheque.AfficherLivre();

        bibliotheque.SupprimerLivre("Peste");

        bibliotheque.AfficherLivre();

    }
}