using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema.AtaskaituModeliai
{
    public class PrekiuAtaskaita
    {
        public int Id { get; set; }
        public int KasosId { get; set; }
        public string Pavadinimas { get; set; }
        public int Kiekis { get; set; }
        public decimal Suma { get; set; }

        public PrekiuAtaskaita(int id, int kasosId, string pavadinimas, int kiekis, decimal suma)
        {
            Id = id;
            KasosId = kasosId;
            Pavadinimas = pavadinimas;
            Kiekis = kiekis;
            Suma = suma;
        }
    }
}
