using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SPA.Program;

namespace SPA
{
    public class Chenil
    {
        public string Libelle { get; set; }
        public TypeChenil Enclos { get; set; }
        public int Capacité { get; set; }
        public int IdListani { get; set; }
        public int IdListSoigneur { get; set; }

        public enum TypeChenil
        {
            Chien,
            Chat
        }

        public Chenil(string libelle, TypeChenil enclos, int capacité, int idListani, int idListSoigneur)
        {
            Libelle = libelle;
            Enclos = enclos;
            Capacité = capacité;
            IdListani = idListani;
            IdListSoigneur = idListSoigneur;
        }
        static List<Chenil> ChenilList = new List<Chenil>();

        public static void MainChenilFonction()
        {
            bool Application = true;
            while (Application)
            {
                Console.WriteLine("Que voulez-vous faire ?:");
                Console.WriteLine("1: Lister tous les chenils");
                Console.WriteLine("2: Trouver un chenil");
                Console.WriteLine("3: Créer/supprimer un chenil");
                Console.WriteLine("4: Ajouter/Retirer un animal dans un chenil");
                Console.WriteLine("5: Assigner/Désassigner un soigneur à chenil");
                Console.WriteLine("0: Retour");
                switch (GetIntFromConsole())
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("oui");
                        break;

                    case 2: Console.WriteLine("oui");
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("oui");
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("oui");
                        Console.Clear();
                        break;

                    case 5:
                        Console.WriteLine("oui");
                        Console.Clear();
                        break;

                    case 0:
                        Console.Clear();
                        Application = false;
                        break;
                }
            }
        }
    }
}
