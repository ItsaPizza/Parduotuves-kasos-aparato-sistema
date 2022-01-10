using Kasos_Aparato_Sistema.Modeliai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparato_Sistema.Repozitorijos
{
    public class UzsakymuRepozitorija
    {
        private List<Uzsakymas> uzsakymai = new List<Uzsakymas>();
        private KasosAparatuRepozitorija _kasosAparatuRepozitorija;
        private PrekiuRepozitorija _prekiuRepozitorija;
        private Random Random = new Random();
        public UzsakymuRepozitorija(PrekiuRepozitorija prekiuRepozitorija, KasosAparatuRepozitorija kasosAparatuRepozitorija)
        {
            _prekiuRepozitorija = prekiuRepozitorija;
            _kasosAparatuRepozitorija = kasosAparatuRepozitorija;

            uzsakymai.Add(new Uzsakymas(GeneruotiUzsakymoId(), GeneruotiUzsakymoLaika(),));
        }
        public Guid GeneruotiUzsakymoId()
        {
            Guid id = Guid.NewGuid();
            return id;
        }
        public DateTime GeneruotiUzsakymoLaika()
        {
            DateTime previousMonthDate = DateTime.Today.AddMonths(-1);
            int year = previousMonthDate.Year;
            int month = previousMonthDate.Month;
            int days = DateTime.DaysInMonth(year, month);            
            var orderTime = new DateTime(year, month, Random.Next(1, days + 1));

            return orderTime;
        }

        public List<int> GeneruotiPrekiuSarasa()
        {
            int bendrasPrekiuKiekis = _prekiuRepozitorija.GautiPrekiuKieki();
            List<int> prekiuSarasas = new List<int>();
            int prekiuKiekis = Random.Next(1, 10); //MAX prekiu kieki galima keisti
            int kasosAparatuKiekis = _kasosAparatuRepozitorija.GautiKasosAparatuKieki();
            int kasosNumeris = Random.Next(1, kasosAparatuKiekis + 1);
            for (int i = 0; i < prekiuKiekis; i++)
            {
                
            }
        }
    }
}
