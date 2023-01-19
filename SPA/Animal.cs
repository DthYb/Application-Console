using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPA
{
    internal class Animal
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public TypeEspece Espece { get; set; }
        public int Taille { get; set; }
        public TySexe Sexe { get; set; }
        public int Age { get; set; }
        public int Poids { get; set; }
        public bool EstSterilise { get; set; }
        public enum TypeEspece
        {
            chien,
            chat
        }

        public enum TySexe
        {
            male,
            femelle
        }

        public Animal(int id, string nom, TypeEspece espece, int taille, TySexe sexe, int age, int poids, bool estSterilise)
        {
            this.Id = id;
            this.Nom = nom;
            this.Espece = espece;
            this.Taille = taille;
            this.Sexe = sexe;
            this.Age = age;
            this.Poids = poids;
            this.EstSterilise = estSterilise;
        }
    }
}
