using ConsoleBibliotheque;
using System;
using System.Globalization;
using System.Resources;
using System.Threading;

class Program
{
    private static CultureInfo cultureInfo = new CultureInfo("fr");
    private static ResourceManager rm = new ResourceManager("GestionBibliotheque.Messages", typeof(Program).Assembly);

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine(rm.GetString("MenuTitle"));
        Console.WriteLine("[1] " + rm.GetString("AddBook"));
        Console.WriteLine("[2] " + rm.GetString("DeleteBook"));
        Console.WriteLine("[3] " + rm.GetString("SearchBook"));
        Console.WriteLine("[4] " + rm.GetString("BorrowBook"));
        Console.WriteLine("[5] " + rm.GetString("ReturnBook"));
        Console.WriteLine("[6] " + rm.GetString("ShowBooks"));
        Console.WriteLine("[7] " + rm.GetString("ChangeLanguage"));
        Console.WriteLine("[8] " + rm.GetString("QuitApp"));
    }

    static void ChangerLangue()
    {
        Console.Clear();
        Console.WriteLine(rm.GetString("LanguageChoice"));
        string choix = Console.ReadLine()?.Trim().ToUpper();

        if (choix == "EN")
            cultureInfo = new CultureInfo("en");
        else
            cultureInfo = new CultureInfo("fr");

        Thread.CurrentThread.CurrentUICulture = cultureInfo;
        rm = new ResourceManager("GestionBibliotheque.Messages", typeof(Program).Assembly);

        Console.WriteLine(rm.GetString("LanguageChanged") + cultureInfo.TwoLetterISOLanguageName.ToUpper());

        Thread.Sleep(1500);
    }

    static void Main(string[] args)
    {
        Bibliotheque bibliotheque = new Bibliotheque(rm);

        string choixOperation = "0";
        string titre;
        string auteur;
        string emprunteur;

        while (choixOperation != "8")
        {
            Menu();
            choixOperation = Console.ReadLine();
            Console.Clear();

            switch (choixOperation)
            {
                case "1":
                    Console.WriteLine("--- " + rm.GetString("AddBook") + " ---");
                    Console.WriteLine(rm.GetString("EnterTitle"));
                    titre = Console.ReadLine();
                    Console.WriteLine(rm.GetString("EnterAuthor"));
                    auteur = Console.ReadLine();
                    bibliotheque.AjouterLivre(new Livre(titre, auteur, rm));
                    break;

                case "2":
                    Console.WriteLine("--- " + rm.GetString("DeleteBook") + " ---");
                    Console.WriteLine(rm.GetString("EnterTitle"));
                    titre = Console.ReadLine();
                    bibliotheque.SupprimerLivre(titre);
                    break;

                case "3":
                    Console.WriteLine("--- " + rm.GetString("SearchBook") + " ---");
                    Console.WriteLine(rm.GetString("EnterTitle"));
                    titre = Console.ReadLine();
                    bibliotheque.RechercherLivre(titre);
                    break;

                case "4":
                    Console.WriteLine("--- " + rm.GetString("BorrowBook") + " ---");
                    Console.WriteLine(rm.GetString("EnterTitle"));
                    titre = Console.ReadLine();
                    Console.WriteLine(rm.GetString("EnterName"));
                    emprunteur = Console.ReadLine();
                    bibliotheque.EmprunterLivre(titre, emprunteur);
                    break;

                case "5":
                    Console.WriteLine("--- " + rm.GetString("ReturnBook") + " ---");
                    Console.WriteLine(rm.GetString("EnterTitle"));
                    titre = Console.ReadLine();
                    bibliotheque.RetournerLivre(titre);
                    break;

                case "6":
                    Console.WriteLine("--- " + rm.GetString("ShowBooks") + " ---");
                    bibliotheque.AfficherLivre();
                    break;

                case "7":
                    ChangerLangue();
                    break;
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
