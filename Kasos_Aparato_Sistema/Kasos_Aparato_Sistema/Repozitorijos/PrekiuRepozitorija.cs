using Kasos_Aparatu_Sistema.Modeliai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema.Repozitorijos
{
    public class PrekiuRepozitorija
    {
        private List<Preke> prekes = new List<Preke>();
        public PrekiuRepozitorija()
        {
            prekes.Add(new Preke(1, 1, "Sonine", 3.99m));
            prekes.Add(new Preke(2, 1, "Kiausiniai", 2.39m));
            prekes.Add(new Preke(3, 1, "Pienas", 1.19m));
            prekes.Add(new Preke(4, 1, "Miltai", 1.99m));

            prekes.Add(new Preke(5, 2, "Dviracio atsvaitas", 3.69m));
            prekes.Add(new Preke(6, 2, "Dviracio grandine", 33.49m));
            prekes.Add(new Preke(7, 2, "Dviracio ratas", 154.99m));
            prekes.Add(new Preke(8, 2, "Dviracio pompa", 20.99m));

            prekes.Add(new Preke(9, 3, "Gitaros stygos", 12.99m));
            prekes.Add(new Preke(10, 3, "Gitaros derintuvas", 15.49m));
            prekes.Add(new Preke(11, 3, "Gitaros deklas", 109.99m));
            prekes.Add(new Preke(12, 3, "Gitaros pedalas", 120.99m));

        }

        public List<Preke> GautiVisasPrekes() => prekes;
        public Preke? GautiPreke(int id) => prekes.SingleOrDefault(x => x.Id == id);
        public int GautiPrekiuKieki() => prekes.Count();
        public List<int> GautiPrekiuNumeriusPagalKasa(int kasa)
        {
            List<int> kasosPrekiuSarasas = new List<int>();
            foreach(var preke in prekes)
            {
                if(preke.KasosId == kasa)
                {
                    kasosPrekiuSarasas.Add(preke.Id);
                }
            }
            return kasosPrekiuSarasas;
        }

    }
}
