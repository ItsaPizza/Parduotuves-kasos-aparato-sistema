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
        public UzsakymuRepozitorija()
        {
            uzsakymai.Add(new Uzsakymas(GeneruotiUzsakymoId(), ))
        }
        public Guid GeneruotiUzsakymoId()
        {
            Guid id = Guid.NewGuid();
            return id;
        }
        public DateTime GeneruotiUzsakymoLaika()
        {
            var previousMonthDate = DateTime.Today.AddMonths(-1);
            var year = previousMonthDate.Year;
            var month = previousMonthDate.Month;
            int days = previousMonthDate.DaysInMonth(year, month);

            return;
        }


    }
}
