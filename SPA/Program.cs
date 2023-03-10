using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using static SPA.AnimalBll;
using static SPA.ChenilBll;
using static SPA.SoigneurBll;
using static System.Net.Mime.MediaTypeNames;

namespace SPA
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur l'appli de la SPA");

            bool menu = true;
            while (menu == true)
            {
                Console.Clear();
                Console.WriteLine("Menu :");
                Console.WriteLine("1: Gestion Animal");
                Console.WriteLine("2: Gestion Chenil");
                Console.WriteLine("3: Gestion Soigneur ");
                Console.WriteLine("0: Quitter l'application");
                Console.WriteLine();
                switch (GetIntFromConsole())
                {
                    case 1:
                        Console.Clear();
                        MainAnimalFonction();
                        break;
                    case 2:
                        Console.Clear();
                        MainChenilFonction();
                        break; 
                    case 3:
                        Console.Clear();
                        MainSoigneurFonction();
                        break; 
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Voulez-vous vraiment sortir de l'application ?");
                        string sortie = Console.ReadLine();
                        switch (sortie.ToLower())
                        {
                            case "yes":
                            case "y":
                            case "o":
                            case "oui":
                                Console.WriteLine("Au revoir");
                                menu = false;
                                break;
                            case "no":
                            case "n":
                            case "non":
                                Console.WriteLine("");
                                break;
                            default:
                                Console.WriteLine("Je n'ai pas compris");
                                break;

                        }
                        break;

                }
            }
        }
        public static int GetIntFromConsole()
        {
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("L'entrée utilisateur doit être un nombre");
                return -1;
            }
        }
    }
}