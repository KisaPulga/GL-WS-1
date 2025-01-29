using System;

namespace GestionBibliotheque
{

    class Program
    {

        static void Main(string[] args)
        {
            Livre l = new Livre("Titanic", "Saoul");
            Console.WriteLine(l);
        }
    }
}