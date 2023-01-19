using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPA
{
    public class Chenil
    {
        public string Libelle { get; set; }
        public TypeChenil Enclos { get; set; }
        public int Capacite { get; set; }
        public HashSet<int> IdListani { get; set; }
        public HashSet<int> IdListSoigneur { get; set; }

        public enum TypeChenil
        {
            Chien,
            Chat
        }

        public Chenil(string libelle, TypeChenil enclos, int capacité)
        {
            Libelle = libelle;
            Enclos = enclos;
            Capacite = capacité;
            IdListani = new HashSet<int>();
            IdListSoigneur = new HashSet<int>();
        }
        
    }
}
