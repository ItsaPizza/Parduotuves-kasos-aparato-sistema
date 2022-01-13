using Kasos_Aparatu_Sistema.Modeliai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema.Repozitorijos
{
    public class KasosAparatuRepozitorija
    {
        private List<KasosAparatas> kasosAparatai = new List<KasosAparatas>();
        public KasosAparatuRepozitorija()
        {
            kasosAparatai.Add(new KasosAparatas(1, "Maisto prekiu kasa"));
            kasosAparatai.Add(new KasosAparatas(2, "Dviracio prekiu kasa"));
            kasosAparatai.Add(new KasosAparatas(3, "Muzikos instrumentu prekiu kasa"));

        }
        public List<KasosAparatas> GautiKasosAparatus() => kasosAparatai;
        public KasosAparatas? GautiKasosAparata(int id) => kasosAparatai.SingleOrDefault(x => x.Id == id);
        public int GautiKasosAparatuKieki() => kasosAparatai.Count();
    }
}
