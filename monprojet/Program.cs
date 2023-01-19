using System;
using System.Collections.Generic;

namespace monprojet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Voiture Voiture1 = new Voiture()
            {                
                Modele = "Clio",
                Couleur = "Noire",
                Marque = "Renault",
                Kilometres = 128000,
                Moteur = Voiture.Motorisation.Thermique,
                DateConstruction= DateTime.Now,
                Immatriculation = "PL-123-AK",
                EstAssure = true
            };



            string value = null;
            if (Voiture1.EstAssure == true)
            {
                value = "La voiture est bien assuré";
            }
            else
            {
                value = "La voiture n'est pas assuré";
            }

            Console.WriteLine("La voiture est une " + Voiture1.Modele + " de couleur " + Voiture1.Couleur + " à moteur " + Voiture1.Moteur + " de la marque " + Voiture1.Marque);
            Console.WriteLine(value + " et est immatriculé " + Voiture1.Immatriculation);
            Voiture1.Accelerer();

            Voiture Voiture2 = new Voiture()
            {
                Modele = "P1",
                Couleur = "Silver",
                Marque = "McLaren",
                Kilometres = 82000,
                Moteur = Voiture.Motorisation.Thermique,
                Immatriculation = "JE-263-GB",
                EstAssure = true,

            };
            Voiture Voiture3 = new Voiture()
            {
                Modele = "M4",
                Couleur = "Lime",
                Marque = "BMW",
                Kilometres = 40000,
                Moteur = Voiture.Motorisation.Thermique,
                Immatriculation = "AD-102-DE",
                EstAssure = true,

            };
            Voiture Voiture4 = new Voiture()
            {
                Modele = "508",
                Couleur = "Bleue",
                Marque = "Peugeot",
                Kilometres = 102000,
                Moteur = Voiture.Motorisation.Thermique,
                Immatriculation = "AH-452-FR",
                EstAssure = false,

            };
            //List<Voiture> Voitures = new List<Voiture>();

            //Voitures.Add(Voiture1);
            //Voitures.Add(Voiture2);
            //Voitures.Add(Voiture3);
            //Voitures.Add(Voiture4);

            List<Voiture> Voitures = new List<Voiture>()
            {
                Voiture1,
                Voiture2,
                Voiture3,
                Voiture4,
                new Voiture()
                {
                    Couleur = "Bleue",
                    EstAssure= true,
                    Immatriculation = "BH-853-KI",
                    Marque="Peugeot",
                    Modele="208",
                    Moteur= Voiture.Motorisation.Thermique,
                }
            };

            //foreach (Voiture voiture in Voitures)
            //{
            //    Console.WriteLine(voiture.Modele);
            //}

            foreach (Voiture voiture in Voitures)
            {
                if (voiture.EstAssure == true)
                {
                    Console.WriteLine(voiture.Modele+ " est assuré");
                }
            }
            foreach (Voiture voiture in Voitures)
            {
                if (voiture.Couleur == "Noire")
                {
                    Console.WriteLine(voiture.Modele + " est " +voiture.Couleur + " construite en " + voiture.DateConstruction);
                }
            }
        }
    }
}