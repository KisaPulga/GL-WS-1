using ConsoleBibliotheque;
using System;

class Program

{
    static void Menu()
    {
        Console.WriteLine("--- GESTION BIBLIOTHEQUE ---");
        Console.WriteLine("[1] Ajouter un livre");
        Console.WriteLine("[2] Supprimer un livre");
        Console.WriteLine("[3] Rechercher un livre");
        Console.WriteLine("[4] Emprunter un livre");
        Console.WriteLine("[5] Retourner un livre");
        Console.WriteLine("[6] Afficher tous les livres");
        Console.WriteLine("[7] Quitter l'application");
    }

    static void Main(string[] args)
    {
        string choixOperation = "0";
        string titre;
        string auteur;
        string emprunteur;

        Bibliotheque bibliotheque = new Bibliotheque();
        while (choixOperation != "7")
        {
            Menu();
            choixOperation = Console.ReadLine();
            switch (choixOperation)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("--- AJOUTER UN LIVRE ---");
                    Console.WriteLine("Veuillez entrer le titre :");
                    titre = Console.ReadLine();
                    Console.WriteLine("Veuillez entrer l'auteur :");
                    auteur = Console.ReadLine();
                    bibliotheque.AjouterLivre(new Livre(titre, auteur));

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("--- SUPPRIMER UN LIVRE ---");
                    Console.WriteLine("Veuillez entrer le titre du livre à supprimer :");
                    titre = Console.ReadLine();
                    bibliotheque.SupprimerLivre(titre);

                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("--- RECHERCHER UN LIVRE ---");
                    Console.WriteLine("Veuillez entrer le titre du livre à rechercher :");
                    titre = Console.ReadLine();
                    bibliotheque.RechercherLivre(titre);

                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("--- EMPRUNTER UN LIVRE ---");
                    Console.WriteLine("Veuillez entrer le titre du livre à emprunter :");
                    titre = Console.ReadLine();
                    Console.WriteLine("Quel est votre nom ?");
                    emprunteur = Console.ReadLine();
                    bibliotheque.EmprunterLivre(titre, emprunteur);

                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("--- RETOURNER UN LIVRE ---");
                    Console.WriteLine("Veuillez entrer le titre du livre à retourner :");
                    titre = Console.ReadLine();
                    bibliotheque.RetournerLivre(titre);

                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("--- LISTE DES LIVRES ---");
                    bibliotheque.AfficherLivre();

                    break;
            }
            Thread.Sleep(2000);
            Console.Clear();

        }


    }
}