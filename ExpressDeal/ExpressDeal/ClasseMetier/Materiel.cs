using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressDeal.ClasseMetier
{
    public class Materiel
    {
        public int materielId { get; set; }
        public string nom { get; set; }

        public string description { get; set; }

        public string marque { get; set; }
        public string taille { get; set; }

        public int dureeLocation { get; set; }
        public double coutLocation { get; set; }
        public double coutRemplacement { get; set; }

        // un objet Categorie
        public Categorie categorie { get; set; }

    }
}
