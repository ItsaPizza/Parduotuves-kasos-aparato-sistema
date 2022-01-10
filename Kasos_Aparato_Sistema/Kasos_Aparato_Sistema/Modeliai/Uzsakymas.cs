using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparato_Sistema.Modeliai
{
    public class Uzsakymas
    {
        public Guid Id { get; set; }
        public DateTime Laikas { get; set; }
        public List<int> PrekiuId { get; set; }

        public Uzsakymas(int id, DateTime laikas, List<int> prekiuId)
        {
            Id = id;
            Laikas = laikas;
            PrekiuId = prekiuId;
        }
    }
}
