using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuMorpion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bienvenu dans le jeu de Morpion, veuillez choisir le nombre de cases : ");
            int nombreDeCase = int.Parse(Console.ReadLine());

            Morpion PremierMorpion = new Morpion(nombreDeCase);
            
            PremierMorpion.SymboleDuJoueurQuiDoitJouer = Symbol.croix;
            while (true)
            {
                PremierMorpion.AfficherMorpion();
                Console.WriteLine(" jouer i : ");
                int i = int.Parse( Console.ReadLine());
                Console.WriteLine(" Jouer j : ");
                int j = int.Parse(Console.ReadLine());

                Tour T = new Tour(i,j);
             

                PremierMorpion.JouerUneCase(T);

                 if(PremierMorpion.DeterminerSymbolGagant() == null)
                 {
                    Console.WriteLine("continuer la partie");
                 }
                 else if (PremierMorpion.DeterminerSymbolGagant() == Symbol.croix)
                 {
                    Console.WriteLine(" la croix a gagner");
                    Console.ReadKey();
                 }
                else
                {
                    Console.WriteLine("le rond a gagner");
                    Console.ReadKey();
                }

            }
        }
    }
}
