using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressDeal.ClasseMetier
{
    public class Location
    {
        public int IdLocation { get; set; }
        public DateTime DateLocation { get; set; }

        public int InventaireId { get; set; }

        public string NomMateriel { get; set; }

        public string NomClient { get; set; }
    }
}
