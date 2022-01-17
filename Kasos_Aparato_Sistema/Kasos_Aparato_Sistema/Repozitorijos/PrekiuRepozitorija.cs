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
        public int PasirinktaPreke = 0;
        private List<Preke> prekes = new List<Preke>();
        public PrekiuRepozitorija()
        {
            prekes.Add(new Preke(1, 1, "Sonine", 3.99m));
            prekes.Add(new Preke(2, 1, "Kiausiniai", 2.39m));
            prekes.Add(new Preke(3, 1, "Pienas", 1.19m));
            prekes.Add(new Preke(4, 1, "Miltai", 1.99m));
            prekes.Add(new Preke(5, 1, "Sviestas", 2.19m));
            prekes.Add(new Preke(6, 1, "Cukrus", 3.59m));
            prekes.Add(new Preke(7, 1, "Druska", 0.99m));

            prekes.Add(new Preke(8, 2, "Dviracio atsvaitas", 3.69m));
            prekes.Add(new Preke(9, 2, "Dviracio grandine", 33.49m));
            prekes.Add(new Preke(10, 2, "Dviracio ratas", 154.99m));
            prekes.Add(new Preke(11, 2, "Dviracio pompa", 20.99m));
            prekes.Add(new Preke(12, 2, "Dviracio vairas", 50.99m));
            prekes.Add(new Preke(13, 2, "Salmas", 99.99m));
            prekes.Add(new Preke(14, 2, "Dviracio pedalas", 18.99m));

            prekes.Add(new Preke(15, 3, "Gitaros stygos", 12.99m));
            prekes.Add(new Preke(16, 3, "Gitaros derintuvas", 15.49m));
            prekes.Add(new Preke(17, 3, "Gitaros deklas", 109.99m));
            prekes.Add(new Preke(18, 3, "Gitaros pedalas", 120.99m));
            prekes.Add(new Preke(19, 3, "Mediatorius", 0.99m));
            prekes.Add(new Preke(20, 3, "Gitaros stiprintuvas", 499.00m));
            prekes.Add(new Preke(21, 3, "Metronomas", 8.99m));

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
