using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace monprojet
{
    public class Voiture
    {
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Couleur { get; set; }
        public int Kilometres { get; set; }
        public string Immatriculation { get; set; }
        public Motorisation Moteur { get; set; }
        public bool EstAssure { get; set; }
        public DateTime DateConstruction { get; set; }

        static void Klaxonner()
        {
            Console.WriteLine("Tut-tut !");
        }

        public enum Motorisation
        {
            Thermique,
            Electrique
        }

        public void Accelerer()
        {
            if (Moteur == Motorisation.Thermique) {
                Console.WriteLine("Vroum !");
            }
            else
            {
                Console.WriteLine("Zzzz");
            }
        }
        

    } 
}
