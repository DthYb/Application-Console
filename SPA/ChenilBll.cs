using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static SPA.Chenil;
using static SPA.Program;
using static SPA.SoigneurBll;
using static SPA.AnimalBll;
using System.Net.Mail;

namespace SPA
{
    internal class ChenilBll
    {
        static List<Chenil> ChenilList = new List<Chenil>()
        {
            new Chenil("ch0", TypeEspece.Chien, 30),
            new Chenil("ch1", TypeEspece.Chat, 20)
        };
        public static void MainChenilFonction()
        {

            //ChenilList[1].IdListani = new List<int>();

            bool application = true;
            while (application)
            {
                Console.WriteLine("Que voulez-vous faire ?:");
                Console.WriteLine("1: Lister tous les chenils");
                Console.WriteLine("2: Trouver un chenil");
                Console.WriteLine("3: Créer/supprimer un chenil");
                Console.WriteLine("4: Ajouter/Retirer un animal dans un chenil");
                Console.WriteLine("5: Assigner/Désassigner un soigneur à chenil");
                Console.WriteLine("0: Retour");
                Console.WriteLine();
                switch (GetIntFromConsole())
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Voici la liste des chenils :");
                        Console.WriteLine();
                        if (ChenilList.Count == 0)
                        {
                            Console.WriteLine("Vide");
                            Console.WriteLine();
                        }
                        else
                        {
                            foreach (Chenil ch in ChenilList)
                            {
                                Console.WriteLine(ch.Libelle + " " + ch.Enclos + " " + ch.Capacite + " " + ch.IdListani.Count + " " + ch.IdListSoigneur.Count);
                                Console.WriteLine();
                            }
                        }
                        break;

                    case 2:
                        if (ChenilList.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun chenil dans la liste.");
                            Console.WriteLine();
                            break;
                        }
                        Console.Clear();
                        int filter = 0;
                        while (filter == 0)
                        {
                            Console.WriteLine("Rechercher un chenil :");
                            string findname = Console.ReadLine();
                            foreach (Chenil ch in ChenilList)
                            {
                                if (ch.Libelle.ToLower() == findname.ToLower())
                                {
                                    Console.WriteLine(ch.Libelle + " " + ch.Enclos + " " + ch.Capacite);
                                    foreach (var listsoi in ch.IdListSoigneur)
                                    {
                                        if (ch.Libelle.ToLower() == findname.ToLower())
                                        {
                                            Console.WriteLine(listsoi);
                                        }
                                    }
                                    Console.WriteLine();
                                    filter = 1;
                                }
                            }
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Créer/supprimer un chenil");
                        Console.WriteLine("1 pour Créer | 2 pour Supprimer | 3 pour retourner au menu");
                        switch (GetIntFromConsole())
                        {
                            case 1:
                                Console.Clear();
                                AddChenil();
                                break;
                            case 2:
                                Console.Clear();
                                DeleteChenil();
                                break;
                            case 3:
                                Console.Clear();
                                break;
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Ajouter/Retirer un animal dans un chenil");
                        Console.WriteLine("1 pour Ajouter | 2 pour Retirer | 3 pour retourner au menu");
                        switch (GetIntFromConsole())
                        {
                            case 1:
                                Console.Clear();
                                AddAnimalToList();
                                break;
                            case 2:
                                Console.Clear();
                                RemoveAnimalFromList();
                                break;
                            case 3:
                                Console.Clear();
                                break;
                        }
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Assigner/Désassigner un soigneur à chenil");
                        Console.WriteLine("1 pour Assigner | 2 pour Désassigner | 3 pour retourner au menu");
                        switch (GetIntFromConsole())
                        {
                            case 1:
                                Console.Clear();
                                AddSoigneurToList();

                                break;
                            case 2:
                                Console.Clear();
                                RemoveSoigneurFromList();

                                break;
                            case 3:
                                Console.Clear();
                                break;
                        }
                        break;
                    case 0:
                        Console.Clear();
                        application = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        static void AddChenil()
        {
            bool annul = false;
            string libtmp = null;
            while (annul == false)
            {
                Console.WriteLine("Pour annuler, entrer 0");
                Console.WriteLine("Indiquer le Libelle du Chenil");
                libtmp = Console.ReadLine();
                annul = true;
                switch (libtmp)
                {
                    case "0":
                        return;
                    default:
                        foreach (Chenil ch in ChenilList)
                        {
                            if (libtmp.ToLower() == ch.Libelle.ToLower())
                            {
                                annul = false;
                                Console.WriteLine("Le libelle doit être unique");
                            }
                        }
                        break;
                }
            }
            annul = false;
            TypeEspece typechenil = TypeEspece.Chien;
            while (annul == false)
            {
                Console.WriteLine("Indiquer le Type d'animal du Chenil | 1 pour chien & 2 pour chat");
                string typetmp = Console.ReadLine();

                do
                {
                    switch (typetmp.ToLower())
                    {
                        case "1":
                            typechenil = TypeEspece.Chien;
                            annul = true;
                            break;
                        case "2":
                            typechenil = TypeEspece.Chat;
                            annul = true;
                            break;
                        default:
                            Console.WriteLine("Erreur, veuillez réssayer");
                            break;

                    }
                }
                while (typetmp == "1" && typetmp == "2");
            }
            annul = false;
            int tailletmp = 0;
            while (annul == false)
            {
                Console.WriteLine("Quel taille fait-il ?");
                do
                {
                    tailletmp = GetIntFromConsole();
                    annul = true;

                }
                while (tailletmp < 0);
                if (tailletmp > 110)
                {
                    Console.WriteLine("Erreur, veuillez réssayer");
                    annul = false;
                }
            }

            ChenilList.Add(new Chenil(libtmp, typechenil, tailletmp));
            Console.Clear();
        }
        static void DeleteChenil()
        {
            if (ChenilList.Count == 0)
            {
                Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun animal dans la liste.");
                Console.WriteLine();
                return;
            }
            string tmplib = null;
            bool annul = false;
            Chenil chenilASuppr = null;

            while (annul == false)
            {
                Console.WriteLine("Rechercher le chenil a supprimer : ");
                tmplib = Console.ReadLine();

                foreach (Chenil ch in ChenilList)
                {
                    if (ch.Libelle.ToLower() == tmplib.ToLower())
                    {
                        Console.WriteLine(ch.Libelle + " " + ch.Enclos + " " + ch.Capacite);
                        Console.WriteLine();
                        chenilASuppr = ch;
                        annul = true;
                    }
                }
            }
            annul = false;
            while (annul == false)
            {
                Console.WriteLine("Êtes-vous sûr de vouloir supprimer ?");
                string sortierep = Console.ReadLine();
                switch (sortierep.ToLower())
                {

                    case "yes":
                    case "y":
                    case "o":
                    case "oui":
                        ChenilList.Remove(chenilASuppr);
                        annul = true;
                        break;
                    case "no":
                    case "n":
                    case "non":
                        Console.Clear();
                        Console.WriteLine("D'accord");
                        Console.WriteLine();
                        annul = true;
                        break;
                    default:
                        Console.WriteLine("Je n'ai pas compris");
                        break;
                }
            }
        }
        static void AddSoigneurToList()
        {
            if (SoigneurList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun soigneur dans la liste.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Appuyez sur échap pour annuler ou autre pour continuer.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return;
            }
            string tmplib = null;
            bool loop = true;
            while (loop == true)
            {
                Console.WriteLine("Rechercher le soigneur à assigner : ");
                tmplib = Console.ReadLine();

                foreach (Soigneur soigneur in SoigneurList)
                {
                    if (soigneur.Nom.ToLower() == tmplib.ToLower() || soigneur.Prenom.ToLower() == tmplib.ToLower())
                    {
                        Console.WriteLine(" | id : " + soigneur.Id + " | Nom : " + soigneur.Nom + " | Prénom : " + soigneur.Prenom + " | Civilité : " + soigneur.Civilite);
                        loop = false;
                    }
                }
            }
            Soigneur soigneurmodif = null;
            int deletenumber = -1;
            loop = true;
            while (loop == true)
            {
                Console.WriteLine();
                Console.WriteLine("Confirmer le soigneur à ajouter ?");
                deletenumber = GetIntFromConsole();
                foreach (Soigneur soigneur in SoigneurList)
                {
                    if (soigneur.Id == deletenumber)
                    {
                        soigneurmodif = soigneur;
                        string libtmp = null;
                        while (libtmp == null || libtmp == "" || libtmp == " ")
                        {
                            Console.Clear();
                            Console.WriteLine("A quel chenil voulez-vous l'assigner ? :");
                            foreach (Chenil ch in ChenilList)
                            {
                                Console.WriteLine(ch.Libelle + " " + ch.Enclos + " " + ch.Capacite + " " + ch.IdListani.Count + " " + ch.IdListSoigneur.Count);
                            }
                            Console.WriteLine();
                            libtmp = Console.ReadLine();
                        }
                        bool Estajoute = false;
                        foreach (Chenil ch in ChenilList)
                        {

                            if (libtmp.ToLower() == ch.Libelle.ToLower())
                            {
                                Estajoute = ch.IdListSoigneur.Add(deletenumber);
                                if (Estajoute)
                                {
                                    Console.WriteLine("Succès");
                                    loop = false;
                                }
                                else
                                {
                                    Console.WriteLine("Soigneur déjà assigné a ce chenil");
                                    loop = false;
                                }
                                Console.WriteLine();
                            }
                        }
                        if (Estajoute == false)
                        {
                            Console.WriteLine("Chenil Introuvable");
                        }
                        break;
                    }
                }
                if (soigneurmodif == null)
                {
                    Console.WriteLine("L'id ne correspond à aucun soigneur dans la liste");
                    deletenumber = -1;
                }
            }
        }
        static void RemoveSoigneurFromList()
        {
            if (SoigneurList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun soigneur dans la liste.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Appuyez sur échap pour annuler ou autre pour continuer.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return;
            }
            Soigneur soigneurmodif = null;
            int deletesoigneur = -1;
            string tmplib = null;
            bool loop = true;
            while (loop == true)
            {
                foreach (Chenil ch in ChenilList)
                {
                    Console.WriteLine(ch.Libelle + " " + ch.Enclos + " " + ch.Capacite + " " + ch.IdListani.Count + " " + ch.IdListSoigneur.Count);
                }
                Console.WriteLine("Quel chenil voulez-vous modifier ?");
                tmplib = Console.ReadLine();
                Chenil chenilselect = ChenilList.Where(ch => ch.Libelle.ToLower() == tmplib.ToLower()).FirstOrDefault();
                if (chenilselect != null)
                {
                    Console.Write("Liste d'Id des soigneurs : ");
                    foreach (int i in chenilselect.IdListSoigneur)
                    {
                        Console.WriteLine(i + ", ");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Chenil introuvable !");
                    continue;
                }

                Console.WriteLine("Choisissez le soigneur a retirer du chenil");
                deletesoigneur = GetIntFromConsole();
                foreach (Soigneur soigneur in SoigneurList)
                {
                    if (soigneur.Id == deletesoigneur)
                    {
                        soigneurmodif = soigneur;
                        chenilselect.IdListSoigneur.Remove(deletesoigneur);
                        Console.WriteLine("Succès");
                        Console.WriteLine();
                        break;
                    }
                }
                loop = true;
                if (soigneurmodif == null)
                {
                    Console.WriteLine("L'id ne correspond à aucun soigneur dans la liste");
                }
                else
                {
                    loop = false;
                }
            }
        }
        static void AddAnimalToList()
        {
            if (AnimauxList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun animal dans la liste.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Appuyez sur échap pour annuler ou autre pour continuer.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return;
            }
            Animal animaltmp = null;
            int addnumber = -1;
            string tmplib = null;
            bool loop = true;
            while (loop == true)
            {
                Console.Clear();
                Console.WriteLine("Rechercher l'animal à ajouter: ");
                tmplib = Console.ReadLine();

                foreach (Animal animaux in AnimauxList)
                {
                    if (animaux.Nom.ToLower() == tmplib.ToLower())
                    {
                        //string messageSterilisation = "";

                        //if (animaux.EstSterilise)
                        //{
                        //    messageSterilisation = "Stérilisé";
                        //}
                        //else
                        //{
                        //    messageSterilisation = "non - Stérilisé";
                        //}

                        //Console.WriteLine(animaux.Id + " " + animaux.Nom + " " + animaux.Taille + " " + animaux.Espece + " " + animaux.Sexe + " " + animaux.Age + " " + animaux.Poids + " " + messageSterilisation);
                        //Console.WriteLine();
                        loop = false;
                    }
                }

            }
            Console.Clear();
            TypeEspece montype = TypeEspece.Chien;
            loop = true;
            while (loop == true)
            {
                foreach (Animal animaux in AnimauxList)
                {
                    if (animaux.Nom.ToLower() == tmplib.ToLower())
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
                        montype = animaux.Espece;
                    }
                }
                Console.WriteLine("Quel animal voulez-vous ajouter ? (Indiquer son ID)");
                addnumber = GetIntFromConsole();
                foreach (Animal animaux in AnimauxList)
                {
                    if (animaux.Id == addnumber)
                    {
                        animaltmp = animaux;
                        loop = false;
                    }
                }
            }
            string cheniltmp = null;
            loop = true;
            while (loop == true)
            {
                Console.WriteLine("A quel chenil voulez-vous l'ajouter ? :");
                foreach (Chenil ch in ChenilList)
                {
                    Console.WriteLine(ch.Libelle + " " + ch.Enclos + " " + ch.Capacite + " " + ch.IdListani.Count + " " + ch.IdListSoigneur.Count);
                }
                Console.WriteLine();
                cheniltmp = Console.ReadLine();
                bool Estajoute = false;
                foreach (Chenil ch in ChenilList)
                {
                    if (montype == ch.Enclos)
                    {
                        if (cheniltmp.ToLower() == ch.Libelle.ToLower())
                        {
                            Estajoute = ch.IdListani.Add(addnumber);
                            if (Estajoute)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Succès");
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Animal déjà assigné a ce chenil");
                                Console.WriteLine();
                                loop = false;
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Le type de l'animal n'est pas accépté par ce chenil");
                    }
                }
            }
        }
        static void RemoveAnimalFromList()
        {
            if (AnimauxList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Impossible d'accéder à ce menu, il n'y a aucun animal dans la liste.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Appuyez sur échap pour annuler ou autre pour continuer.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return;
            }
            string libeltmp = null;
            bool loop = true;
            while (loop)
            {
                foreach (Chenil ch in ChenilList)
                {
                    Console.WriteLine(ch.Libelle + " " + ch.Enclos + " " + ch.Capacite + " " + ch.IdListani.Count + " " + ch.IdListSoigneur.Count);
                }
                Console.WriteLine("Quel chenil voulez-vous modifier ?");
                libeltmp = Console.ReadLine();
                foreach (Chenil ch in ChenilList)
                {
                    if (ch.Libelle.ToLower() == libeltmp.ToLower())
                    {
                        Console.WriteLine(ch.Libelle + " " + ch.Enclos + " " + ch.Capacite + " " + ch.IdListani.Count + " " + ch.IdListSoigneur.Count);
                        loop = false;
                    }
                }
            }
            int tmpani = -1;
            Animal animalmodif = null;
            loop = true;
            while (loop)
            {
                Chenil chenilselect = ChenilList.Where(ch => ch.Libelle.ToLower() == libeltmp.ToLower()).FirstOrDefault();
                if (chenilselect != null)
                {
                    foreach (Chenil ch in ChenilList)
                    {
                        if (chenilselect.IdListani == ch.IdListani)
                        {
                            if (ch.IdListani.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("La liste selectionnée est vide");
                                Console.WriteLine();
                                return;
                            }
                        }
                    }
                    Console.Write("Liste d'Id des animaux : ");
                    foreach (int i in chenilselect.IdListani)
                    {
                        Console.WriteLine(i + ", ");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Chenil introuvable !");
                    continue;
                }

                Console.WriteLine("Choisissez l'animal a retirer du chenil");
                tmpani = GetIntFromConsole();
                foreach (Animal animaux in AnimauxList)
                {
                    if (animaux.Id == tmpani)
                    {
                        animalmodif = animaux;
                        chenilselect.IdListani.Remove(tmpani);
                        Console.Clear();
                        Console.WriteLine("Succès");
                        Console.WriteLine();
                        break;
                    }
                }
                loop = true;
                if (animalmodif == null)
                {
                    Console.WriteLine("L'id ne correspond à aucun animal dans la liste");
                }
                else
                {
                    loop = false;
                }
            }
        }
    }
}
