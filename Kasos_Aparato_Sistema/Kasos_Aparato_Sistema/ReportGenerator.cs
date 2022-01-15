using Kasos_Aparatu_Sistema.AtaskaituModeliai;
using Kasos_Aparatu_Sistema.Modeliai;
using Kasos_Aparatu_Sistema.Repozitorijos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema
{
    public class ReportGenerator
    {
        private KasosAparatuRepozitorija _kasosAparatuRepozitorija;
        private PrekiuRepozitorija _prekiuRepozitorija;
        private UzsakymuRepozitorija _uzsakymuRepozitorija;

        public ReportGenerator(KasosAparatuRepozitorija kasosAparatuRepozitorija,
            PrekiuRepozitorija prekiuRepozitorija,
            UzsakymuRepozitorija uzsakymuRepozitorija)
        {
            _kasosAparatuRepozitorija = kasosAparatuRepozitorija;
            _prekiuRepozitorija = prekiuRepozitorija;
            _uzsakymuRepozitorija = uzsakymuRepozitorija;
        }

        public List<UzsakymuAtaskaitosModelis> GeneruotiVisuUzsakymuAtaskaita()
        {
            List<UzsakymuAtaskaitosModelis> uzsakymuAtaskaita = new List<UzsakymuAtaskaitosModelis>();
            List<Uzsakymas> visiUzsakymai = _uzsakymuRepozitorija.GautiVisusUzsakymus();

            foreach (var uzsakymas in visiUzsakymai)
            {
                decimal uzsakymoSuma = 0m;
                foreach (var id in uzsakymas.PrekiuId)
                {
                    Preke? preke = _prekiuRepozitorija.GautiPreke(id);
                    if (preke != null)
                    {
                        uzsakymoSuma += preke.Kaina;
                    }
                }
                var ataskaitosUzsakymas = new UzsakymuAtaskaitosModelis(uzsakymas.Laikas, uzsakymas.Id, uzsakymas.KasosId, uzsakymoSuma);
                uzsakymuAtaskaita.Add(ataskaitosUzsakymas);
            }
            List<UzsakymuAtaskaitosModelis> sortedUzsakymuAtaskaita = uzsakymuAtaskaita.OrderBy(x => x.Laikas).ToList();
            return sortedUzsakymuAtaskaita;
        }
    }
}
