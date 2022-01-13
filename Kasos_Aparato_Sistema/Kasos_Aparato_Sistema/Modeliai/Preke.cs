using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema.Modeliai
{
    public class Preke
    {
        public int Id { get; set; }
        public int KasosId { get; set; }
        public string Pavadinimas { get; set; }
        public decimal Kaina { get; set; }

        public Preke(int id, int kasosId, string pavadinimas, decimal kaina)
        {
            Id = id;
            KasosId = kasosId;
            Pavadinimas = pavadinimas;
            Kaina = kaina;
        }
    }
}
