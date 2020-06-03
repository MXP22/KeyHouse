using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeyHouse.Models
{
    public class LogModel
    {
        public string Titre { get; set; }
        public string Description { get; set; }
        public int Surface { get; set; }

        public int Nomberdepieces { get; set; }
        public decimal prix { get; set; }

        public string Adresse { get; set; }

        public Logements Logements { get; set; }

        public string typelogement { get; set; }

        public string villes { get; set; }

        public ImageLogement image { get; set; }

         public List<string> typeLogement()
        {
            List<string> vs = new List<string>() { "Villa", "Appartement", "Maison", "Studio", "Terrain" };

            return vs;

        }    

    }
}