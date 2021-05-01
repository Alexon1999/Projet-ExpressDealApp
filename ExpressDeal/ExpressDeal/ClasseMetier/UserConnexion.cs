using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressDeal.ClasseMetier
{
    public class UserConnexion
    {
        public bool autoriser { get; set; }
        public string error { get; set; }

        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }

        public string  imageUrl { get; set; }
        public string email { get; set; }
        public int adresseId { get; set; }
        public int magasinId { get; set; }

        public bool actif { get; set; }
    }
}
