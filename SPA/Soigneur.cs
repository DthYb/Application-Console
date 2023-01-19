using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPA
{
    public class Soigneur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public TypeCivilite Civilite { get; set; }

        public enum TypeCivilite
        {
            Homme,
            Femme
        }

        public Soigneur (int id, string nom, string prenom, TypeCivilite civilite)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Civilite = civilite;
        }
    }
}
