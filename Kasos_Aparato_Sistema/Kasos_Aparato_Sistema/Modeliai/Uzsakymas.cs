using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema.Modeliai
{
    public class Uzsakymas
    {
        public Guid Id { get; set; }
        public DateTime Laikas { get; set; }
        public int KasosId { get; set; }
        public List<int> PrekiuId { get; set; }

        public Uzsakymas(Guid id, DateTime laikas, int kasosId, List<int> prekiuId)
        {
            Id = id;
            Laikas = laikas;
            KasosId = kasosId;
            PrekiuId = prekiuId;
        }
    }
}
