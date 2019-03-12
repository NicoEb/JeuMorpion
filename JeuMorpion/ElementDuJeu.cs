using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuMorpion
{
    public class Tour
    {
        public int IndexLigneJouee;
        public int IndexColonneJouee;
        public Tour(int i,int j)
        {
            IndexColonneJouee = i;
            IndexLigneJouee = j;
        }
    }

    public enum Symbol
    {
        croix,
        rond,
    }

    public class Case
    {
        public Symbol? symboleCourant;

        public void PositionnerSymbol(Symbol nouveauSymbol)
        {
            this.symboleCourant = nouveauSymbol;
        }
    }

    public class Morpion
    {
        public Case[,] cases;
        public Symbol SymboleDuJoueurQuiDoitJouer;


        public Morpion()
        {
            this.cases = new Case[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Case caseCourant = new Case();
                    caseCourant.symboleCourant = null;
                    this.cases[i, j] = caseCourant;
                }
            }
        }
        public Morpion(int L)
        {
            this.cases = new Case[L, L];
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < L; j++)
                {
                    Case caseCourant = new Case();
                    caseCourant.symboleCourant = null;
                    this.cases[i, j] = caseCourant;
                }
            }

        }
        

        public void JouerUneCase(Tour tourAjouer)
        {
            // 1ère étape:  récupère dans le grille de morpion la cellule qui correspond
            Case LaCaseAJouer = this.cases[tourAjouer.IndexLigneJouee, tourAjouer.IndexColonneJouee];

            // 2 ième étape :  sur cette case, je lui positionne le symbole du joueur courant
            Symbol symbolAPositionnerDansCaseJouee = this.SymboleDuJoueurQuiDoitJouer;
            LaCaseAJouer.PositionnerSymbol(symbolAPositionnerDansCaseJouee);

            // 3 ième étape : J'inverse le joueur courant

            Symbol leProchainSymbolQuiDoitJouer = this.SymboleDuJoueurQuiDoitJouer == Symbol.croix ? Symbol.rond : Symbol.croix;
            this.SymboleDuJoueurQuiDoitJouer = leProchainSymbolQuiDoitJouer;

        }

        public Symbol? DeterminerSymbolGagant()
        {
            for (int l = 0; l < 3; l++)

            {

                if (this.cases[l, 0].symboleCourant != null && this.cases[l, 0].symboleCourant == this.cases[l, 1].symboleCourant && this.cases[l, 1].symboleCourant == this.cases[l, 2].symboleCourant)
                {
                    return this.cases[l, 0].symboleCourant;
                }

            }
            for (int c = 0; c < 3; c++)

            {

                if (this.cases[0, c].symboleCourant != null && this.cases[0, c].symboleCourant == this.cases[1, c].symboleCourant && this.cases[1, c].symboleCourant == this.cases[2, c].symboleCourant)
                {
                    return this.cases[0, c].symboleCourant;
                }

            }

            if (this.cases[0, 0].symboleCourant != null && this.cases[0, 0].symboleCourant == this.cases[1, 1].symboleCourant && this.cases[0, 0].symboleCourant == this.cases[2, 2].symboleCourant)
            {
                return this.cases[0, 0].symboleCourant;
            }

            if (this.cases[2, 0].symboleCourant != null && this.cases[2, 0].symboleCourant == this.cases[1, 1].symboleCourant && this.cases[2, 0].symboleCourant == this.cases[0, 2].symboleCourant)
            {
                return this.cases[0, 0].symboleCourant;
            }

            return null;
        }

        public void AfficherMorpion()
        {
            Console.Clear();

            for (int i = 0; i < this.cases.GetLength(0); i++)
            {
                for (int j = 0; j < this.cases.GetLength(0); j++)
                {
                    if (this.cases[i, j].symboleCourant == Symbol.croix)
                    {
                        Console.Write("X|");
                    }
                    else if (this.cases[i, j].symboleCourant == Symbol.rond)
                    {
                        Console.Write("O|");
                    }
                    else
                    {
                        Console.Write("_|");
                    }


                }
                Console.Write("\n");
            }

            if (this.SymboleDuJoueurQuiDoitJouer == Symbol.croix)
            {
                Console.Write(" c'est au joueur X de jouer ");
            }

            else if (this.SymboleDuJoueurQuiDoitJouer == Symbol.rond)
            {
                Console.Write(" c'est au joueur O de jouer ");
            }


        }



    }
}
