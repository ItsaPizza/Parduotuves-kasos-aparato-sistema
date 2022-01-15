using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema.AtaskaituModeliai
{
    public class UzsakymuAtaskaitosModelis
    {
        public DateTime Laikas { get; set; }
        public Guid UzsakymoId { get; set; }
        public int KasosId { get; set; }
        public decimal UzsakymoSuma { get; set; }

        public UzsakymuAtaskaitosModelis(DateTime laikas, Guid uzsakymoId, int kasosId, decimal uzsakymoSuma)
        {
            Laikas = laikas;
            UzsakymoId = uzsakymoId;
            KasosId = kasosId;
            UzsakymoSuma = uzsakymoSuma;
        }
    }
}
