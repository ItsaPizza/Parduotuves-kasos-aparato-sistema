using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema.Modeliai
{
    public class KasosAparatas
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }

        public KasosAparatas(int id, string pavadinimas)
        {
            Id = id;
            Pavadinimas = pavadinimas;
        }
    }
}
