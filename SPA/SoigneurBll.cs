using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SPA.Soigneur;
using static SPA.Program;
using static System.Net.Mime.MediaTypeNames;
using static SPA.Chenil;

namespace SPA
{
    internal class SoigneurBll
    {
        public static List<Soigneur> SoigneurList = new List<Soigneur>()
        {
            new Soigneur(0, "Rein", "Jack", TypeCivilite.Homme),
            new Soigneur(1, "Rein", "Christoff", TypeCivilite.Homme)
        };
        public static void MainSoigneurFonction()
        {
            bool menu = true;
            while (menu == true)
            {
                Console.WriteLine("Que voulez-vous faire ?:");
                Console.WriteLine("1: Lister tous les soigneurs ");
                Console.WriteLine("2: Trouver un soigneur");
                Console.WriteLine("3: Ajouter/Retirer un soigneur");
                Console.WriteLine("0: Retour");
                Console.WriteLine();
                switch (GetIntFromConsole())
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Voici la liste des soigneurs :");
                        Console.WriteLine();
                        if (SoigneurList.Count == 0)
                        {
                            Console.WriteLine("Vide");
                        }
                        else
                        {
                            foreach (Soigneur soigneur in SoigneurList)
                            {
                                Console.WriteLine(soigneur.Id + " " + soigneur.Nom + " " + soigneur.Prenom + " " + soigneur.Civilite);
                            }
                        }
                        Console.WriteLine();
                        break;

                    case 2:
                        if (SoigneurList.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun soigneur dans la liste.");
                            Console.WriteLine();
                            break;
                        }
                        Console.Clear();
                        int filter = 0;
                        while (filter == 0)
                        {
                            Console.WriteLine("Rechercher un soigneur :");
                            string findname = Console.ReadLine();
                            foreach (Soigneur soigneur in SoigneurList)
                            {
                                if (soigneur.Nom.ToLower() == findname.ToLower())
                                {
                                    Console.WriteLine(soigneur.Id + " " + soigneur.Nom + " " + soigneur.Prenom + " " + soigneur.Civilite);
                                    Console.WriteLine();
                                    filter = 1;
                                }
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Ajouter/Retirer un soigneur");
                        Console.WriteLine("1 pour Ajouter | 2 pour Retirer | 3 pour retourner au menu");
                        switch (GetIntFromConsole())
                        {
                            case 1:
                                Console.Clear();
                                AddSoigneur();

                                break;
                            case 2:
                                Console.Clear();
                                RemoveSoigneur();

                                break;
                            case 3:
                                Console.Clear();
                                break;
                        }
                        break;
                    case 0:
                        Console.Clear();
                        menu = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        static void AddSoigneur()
        {
            Console.WriteLine("Appuyez sur échap pour annuler ou autre pour continuer.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return;
            }
            Console.Clear();
            bool loop = true;
            string nomtmp = null;
            string prenomtmp = null;
            while (loop == true)
            {
                Console.WriteLine("Indiquer le nom du soignant");
                Console.WriteLine();
                nomtmp = Console.ReadLine();

                Console.WriteLine("Indiquer le prénom du soignant");
                Console.WriteLine();
                prenomtmp = Console.ReadLine();
                loop = false;
                foreach (Soigneur soigneur in SoigneurList)
                {
                    if (nomtmp.ToLower() == soigneur.Nom.ToLower() && prenomtmp.ToLower() == soigneur.Prenom.ToLower())
                    {
                        Console.WriteLine("Employé déjà enregistré");
                        loop = true;
                    }
                }
            }
            loop = true;
            Soigneur.TypeCivilite typecivilite = Soigneur.TypeCivilite.Homme;
            while (loop == true)
            {
                Console.WriteLine("Indiquer la civilité | 1 pour Homme & 2 pour Femme");
                string typetmp = Console.ReadLine();

                do
                {
                    switch (typetmp.ToLower())
                    {
                        case "1":
                            typecivilite = Soigneur.TypeCivilite.Homme;
                            loop = false;
                            break;
                        case "2":
                            typecivilite = Soigneur.TypeCivilite.Femme;
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Erreur, veuillez réssayer");
                            break;

                    }
                }
                while (typetmp == "1" && typetmp == "2");
            }
            int intTmp = SoigneurList.Count;

            SoigneurList.Add(new Soigneur(intTmp, nomtmp, prenomtmp, typecivilite));
            Console.Clear();
        }
        static void RemoveSoigneur()
        {
            if (SoigneurList.Count == 0)
            {
                Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun animal dans la liste.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Appuyez sur échap pour annuler ou autre pour continuer.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return;
            }
            Console.Clear();

            Soigneur soigneurdel = null;
            string tmplib = null;
            bool loop = true;
            while (loop == true)
            {
                Console.WriteLine("Rechercher le soigneur à retirer : ");
                tmplib = Console.ReadLine();

                foreach (Soigneur soigneur in SoigneurList)
                {
                    if (soigneur.Nom.ToLower() == tmplib.ToLower() || soigneur.Prenom.ToLower() == tmplib.ToLower())
                    {
                        Console.WriteLine(" | id : " + soigneur.Id + " | Nom : " + soigneur.Nom + " | Prénom : " + soigneur.Prenom + " | Civilité : " + soigneur.Civilite);
                        soigneurdel = soigneur;
                        loop = false;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Quel soigneur doit-être retiré ?");
            int deletenumber = -1;
            loop = true;
            while (loop == true)
            {
                deletenumber = GetIntFromConsole();
                foreach (Soigneur soigneur in SoigneurList)
                {
                    if (soigneur.Id == deletenumber)
                    {
                        soigneurdel = soigneur;
                        loop = false;
                        break;
                    }
                }
                if (soigneurdel == null)
                {
                    Console.WriteLine("L'id ne correspond à aucun soigneur dans la liste");
                    deletenumber = -1;
                }
            }

            loop = true;
            while (loop == true)
            {
                Console.WriteLine("Êtes-vous sûr de vouloir supprimer ?");
                string sortierep = Console.ReadLine();
                switch (sortierep.ToLower())
                {

                    case "yes":
                    case "y":
                    case "o":
                    case "oui":
                        SoigneurList.Remove(soigneurdel);
                        loop = false;
                        break;
                    case "no":
                    case "n":
                    case "non":
                        Console.Clear();
                        Console.WriteLine("D'accord");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Je n'ai pas compris");
                        break;
                }
            }
        }
    }
}
