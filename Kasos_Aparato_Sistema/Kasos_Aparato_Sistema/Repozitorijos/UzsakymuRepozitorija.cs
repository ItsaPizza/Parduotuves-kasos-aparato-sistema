using Kasos_Aparatu_Sistema.Modeliai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema.Repozitorijos
{
    public class UzsakymuRepozitorija
    {
        private List<Uzsakymas> uzsakymai = new List<Uzsakymas>();
        private KasosAparatuRepozitorija _kasosAparatuRepozitorija;
        private PrekiuRepozitorija _prekiuRepozitorija;
        private Random Random = new Random();
        public UzsakymuRepozitorija(PrekiuRepozitorija prekiuRepozitorija, KasosAparatuRepozitorija kasosAparatuRepozitorija, int uzsakymuSkaicius)
        {
            _prekiuRepozitorija = prekiuRepozitorija;
            _kasosAparatuRepozitorija = kasosAparatuRepozitorija;
            GeneruotiUzsakyma(uzsakymuSkaicius);
        }
        private Guid GeneruotiUzsakymoId()
        {
            Guid id = Guid.NewGuid();
            return id;
        }
        private DateTime GeneruotiUzsakymoLaika()
        {
            DateTime previousMonthDate = DateTime.Today.AddMonths(-1);
            int year = previousMonthDate.Year;
            int month = previousMonthDate.Month;
            int days = DateTime.DaysInMonth(year, month);            
            var orderTime = new DateTime(year, month, Random.Next(1, days + 1), Random.Next(8,24),Random.Next(0,60),Random.Next(0,60));

            return orderTime;
        }
        private List<int> GeneruotiPrekiuSarasa(int kasosNumeris)
        {
            int bendrasPrekiuKiekis = _prekiuRepozitorija.GautiPrekiuKieki();
            List<int> prekiuSarasas = new List<int>();
            int prekiuKiekis = Random.Next(1, 10); //MIN ir MAX prekiu kiekis keičiamas pagal poreikį
            List<int> kasosPrekiuSarasas = _prekiuRepozitorija.GautiPrekiuNumeriusPagalKasa(kasosNumeris);
            for (int i = 0; i < prekiuKiekis; i++)
            {
                int prekesId = Random.Next(kasosPrekiuSarasas.Min(), kasosPrekiuSarasas.Max()+1);
                prekiuSarasas.Add(prekesId);
            }

            return prekiuSarasas;
        }
        private void GeneruotiUzsakyma(int uzsakymuSkaicius)
        {
            int kasosAparatuKiekis = _kasosAparatuRepozitorija.GautiKasosAparatuKieki();
            
            for (int i = 0; i < uzsakymuSkaicius; i++)
            {
                int kasosNumeris = Random.Next(1, kasosAparatuKiekis + 1);
                uzsakymai.Add(new Uzsakymas(GeneruotiUzsakymoId(), GeneruotiUzsakymoLaika(), kasosNumeris, GeneruotiPrekiuSarasa(kasosNumeris)));
            }
        }
        public List<Uzsakymas> GautiVisusUzsakymus() => uzsakymai;
        public List<DateTime> GautiVisuUzsakymuLaikus()
        {
            List<DateTime> uzsakymuLaikai = new List<DateTime>();
            foreach (var uzsakymas in uzsakymai)
            {
                uzsakymuLaikai.Add(uzsakymas.Laikas);
            }
            return uzsakymuLaikai;
        }
    }
}
