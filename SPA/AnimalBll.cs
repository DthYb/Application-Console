using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SPA.Program;
using static SPA.Animal;

namespace SPA
{
    internal class AnimalBll
    {
        public static List<Animal> AnimauxList = new List<Animal>()
        {
            new Animal(0, "Rex", TypeEspece.Chien, 35, 0, 8, 6, true),
            new Animal(1, "ralph", TypeEspece.Chien, 25, 0, 6, 3, true)
        };
        public static void MainAnimalFonction()
        {
            //Animal animal1 = new Animal(0, "Rex", Animal.TypeEspece.chien, 35, 0, 8, 6, true);
            //Animal animal2 = new Animal(1, "ralph", Animal.TypeEspece.chien, 25, 0, 6, 3, true);
            //AnimauxList.Add(animal1);
            //AnimauxList.Add(animal2);

            Console.Clear();
            bool Application = true;
            while (Application)
            {

                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("1: Lister tous les animaux ?");
                Console.WriteLine("2: ajouter un animal ?");
                Console.WriteLine("3: retirer un animal ?");
                Console.WriteLine("4: rechercher un animal ?");
                Console.WriteLine("0: Retour");
                Console.WriteLine();
                switch (GetIntFromConsole())
                {
                    case 1: //Lister
                        Console.Clear();
                        foreach (Animal animaux in AnimauxList)
                        {
                            string messageSterilisation = "";

                            if (animaux.EstSterilise)
                            {
                                messageSterilisation = "Stérilisé";
                            }
                            else
                            {
                                messageSterilisation = "non - Stérilisé";
                            }

                            Console.WriteLine(animaux.Id + " " + animaux.Nom + " " + animaux.Taille + " " + animaux.Espece + " " + animaux.Sexe + " " + animaux.Age + " " + animaux.Poids + " " + messageSterilisation);
                        }
                        Console.WriteLine("Fin");
                        Console.WriteLine();
                        break;
                    case 2:  //Créer et ajouter
                        Console.Clear();
                        AddAnimal(AnimauxList);
                        Console.WriteLine();
                        break;
                    case 3:  //suprimer
                        Console.Clear();
                        DeleteAnimal(AnimauxList);
                        break;

                    case 4: //Filter
                        if (AnimauxList.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun animal dans la liste.");
                            Console.WriteLine();
                            break;
                        }
                        Console.Clear();
                        int filter = 0;
                        while (filter == 0)
                        {
                            Console.WriteLine("Quel est le nom de l'animal que vous cherchez ?");
                            string findname = Console.ReadLine();
                            foreach (Animal animaux in AnimauxList)
                            {
                                if (animaux.Nom.ToLower() == findname.ToLower())
                                {
                                    string messageSterilisation = "";

                                    if (animaux.EstSterilise)
                                    {
                                        messageSterilisation = "Stérilisé";
                                    }
                                    else
                                    {
                                        messageSterilisation = "non - Stérilisé";
                                    }

                                    Console.WriteLine(animaux.Id + " " + animaux.Nom + " " + animaux.Taille + " " + animaux.Espece + " " + animaux.Sexe + " " + animaux.Age + " " + animaux.Poids + " " + messageSterilisation);
                                    Console.WriteLine();
                                    filter = 1;
                                }
                            }
                        }
                        break;
                    case 0:
                        Console.Clear();
                        Application = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        static void DeleteAnimal(List<Animal> AnimauxList)
        {
            if (AnimauxList.Count == 0)
            {
                Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun animal dans la liste.");
                Console.WriteLine();
                return;
            }
            bool del1 = false;
            while (del1 == false)
            {
                Console.WriteLine("Rechercher l'animal à supprimer : ");
                string delname = Console.ReadLine();
                foreach (Animal animaux in AnimauxList)
                {
                    if (animaux.Nom.ToLower() == delname.ToLower())
                    {
                        string messageSterilisation = "";

                        if (animaux.EstSterilise)
                        {
                            messageSterilisation = "Stérilisé";
                        }
                        else
                        {
                            messageSterilisation = "non - Stérilisé";
                        }

                        Console.WriteLine(animaux.Id + " " + animaux.Nom + " " + animaux.Taille + " " + animaux.Espece + " " + animaux.Sexe + " " + animaux.Age + " " + animaux.Poids + " " + messageSterilisation);
                        del1 = true;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Quel animal souhaitez-vous supprimer ?");
            int deletenumber = -1;
            Animal tmpani = null;
            while (deletenumber < 0)
            {
                deletenumber = GetIntFromConsole();
                foreach (Animal animaux in AnimauxList)
                {
                    if (animaux.Id == deletenumber)
                    {
                        tmpani = animaux;
                        break;
                    }
                }
                if (tmpani == null)
                {
                    Console.WriteLine("L'id ne correspond à aucun animal dans la liste");
                    deletenumber = -1;
                }
            }
            Console.WriteLine("Êtes-vous sûr de vouloir supprimer ?");
            string sortierep = Console.ReadLine();
            switch (sortierep.ToLower())
            {

                case "yes":
                case "y":
                case "o":
                case "oui":
                    AnimauxList.Remove(tmpani);
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

        static void AddAnimal(List<Animal> AnimauxList)
        {
            int idnew = AnimauxList.Count;

            bool nomnull = false;
            string nomRep = null;
            while (nomnull == false)
            {
                if (nomRep == null || nomRep == " " || nomRep == "")
                {
                    Console.Clear();
                    Console.WriteLine("Comment s'appelle-t-il ?");
                    nomRep = Console.ReadLine();
                }
                else
                {
                    nomnull = true;
                }
            }

            TypeEspece montype = TypeEspece.Chien;
            bool esp = false;
            while (esp == false)
            {
                Console.WriteLine("De quel èspèce appartient-il ? 1 pour chien, 2 pour chat");
                string especeRep = Console.ReadLine();

                do
                {
                    switch (especeRep.ToLower())
                    {
                        case "1":
                            montype = TypeEspece.Chien;
                            esp = true;
                            break;
                        case "2":
                            montype = TypeEspece.Chat;
                            esp = true;
                            break;
                        default:
                            Console.WriteLine("Erreur, veuillez réssayer");
                            break;

                    }
                }
                while (especeRep == "1" && especeRep == "2");
            }

            string estSteriliseRep = null;
            bool estSterilise = false;
            bool ste = false;
            while (ste == false)
            {
                Console.WriteLine("Est-il stérilisé ?");
                estSteriliseRep = Console.ReadLine();
                switch (estSteriliseRep.ToLower())

                {
                    case "yes":
                    case "y":
                    case "o":
                    case "oui":
                        estSterilise = true;
                        ste = true;
                        break;
                    case "no":
                    case "n":
                    case "non":
                        estSterilise = true;
                        ste = true;
                        break;
                    default:
                        Console.WriteLine("Veuillez indiquer si l'animal est stérilisé");
                        break;
                }
            }

            int tailleInt = 0;
            bool tailletmp = false;
            while (tailletmp == false)
            {
                Console.WriteLine("Quel taille fait-il ?");
                do
                {
                    tailleInt = GetIntFromConsole();
                    tailletmp = true;

                }
                while (tailleInt < 0);
                if (tailleInt > 110)
                {
                    Console.WriteLine("Erreur, veuillez réssayer");
                    tailletmp = false;
                }
            }

            Animal.TySexe sexetype = Animal.TySexe.male;
            bool sexe = false;
            while (sexe == false)
            {
                Console.WriteLine("De quel Sexe est-il? 1 pour male, 2 pour femelle");
                string sexeRep = Console.ReadLine();

                do
                {
                    switch (sexeRep.ToLower())
                    {
                        case "1":
                            sexetype = Animal.TySexe.male;
                            sexe = true;
                            break;
                        case "2":
                            sexetype = Animal.TySexe.femelle;
                            sexe = true;
                            break;
                        default:
                            Console.WriteLine("Erreur, veuillez réssayer");
                            break;

                    }
                }
                while (sexeRep == "1" && sexeRep == "2");
            }

            int ageInt = 0;
            bool agetmp = false;
            while (agetmp == false)
            {
                Console.WriteLine("Quel age a-t-il ?");
                do
                {
                    ageInt = GetIntFromConsole();
                    agetmp = true;

                }
                while (ageInt < 0);
                if (ageInt > 20)
                {
                    Console.WriteLine("Erreur, veuillez réssayer");
                    agetmp = false;
                }
            }

            int poidsInt = 0;
            bool poidstmp = false;
            while (poidstmp == false)
            {
                Console.WriteLine("Quel poids fait-il ?");
                do
                {
                    poidsInt = GetIntFromConsole();
                    poidstmp = true;

                }
                while (poidsInt < 0);
                if (poidsInt > 30)
                {
                    Console.WriteLine("Erreur, veuillez réssayer");
                    poidstmp = false;
                }
            }

            AnimauxList.Add(new Animal(idnew, nomRep, montype, tailleInt, sexetype, ageInt, poidsInt, estSterilise));
            Console.Clear();
        }
    }
}


