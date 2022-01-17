﻿using Kasos_Aparatu_Sistema.Modeliai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema.Repozitorijos
{
    public class KasosAparatuRepozitorija
    {
        public int PasirinktaKasa = 0;
        private List<KasosAparatas> kasosAparatai = new List<KasosAparatas>();
        public KasosAparatuRepozitorija()
        {
            kasosAparatai.Add(new KasosAparatas(1, "Maisto prekių kasa"));
            kasosAparatai.Add(new KasosAparatas(2, "Dviracio prekių kasa"));
            kasosAparatai.Add(new KasosAparatas(3, "Muzikos instrumentų prekių kasa"));

        }
        public List<KasosAparatas> GautiKasosAparatus() => kasosAparatai;
        public KasosAparatas? GautiKasosAparata(int id) => kasosAparatai.SingleOrDefault(x => x.Id == id);
        public int GautiKasosAparatuKieki() => kasosAparatai.Count();
    }
}
