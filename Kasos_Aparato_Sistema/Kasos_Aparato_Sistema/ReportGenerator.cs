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
        public void RodytiUzsakymaPagalId(Guid uzsakymoId)
        {
            List<Uzsakymas> visiUzsakymai = _uzsakymuRepozitorija.GautiVisusUzsakymus();
            foreach (var uzsakymas in visiUzsakymai)
            {
                if (uzsakymas.Id == uzsakymoId)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Uzsakymo ID: {uzsakymas.Id}, uzsakymo laikas: {uzsakymas.Laikas}, kasos numeris: {uzsakymas.KasosId}");
                    Console.WriteLine("Uzsakymo turinys:");
                    List<int> prekiuId = uzsakymas.PrekiuId.ToList();
                    prekiuId.Sort();
                    decimal prekiuSuma = 0m;
                    foreach (var id in prekiuId)
                    {
                        Preke? preke = _prekiuRepozitorija.GautiPreke(id);
                        if (preke != null)
                        {
                            prekiuSuma += preke.Kaina;
                            Console.WriteLine($"Prekes ID: {preke.Id}, prekes pavadinimas: {preke.Pavadinimas}, prekes kaina: {preke.Kaina}");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Bendra uzsakymo suma: {prekiuSuma}");
                }
            }
        }
        public List<UzsakymuAtaskaita> GeneruotiVisuUzsakymuAtaskaita()
        {
            var uzsakymuAtaskaita = new List<UzsakymuAtaskaita>();
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
                var ataskaitosUzsakymas = new UzsakymuAtaskaita(uzsakymas.Laikas, uzsakymas.Id, uzsakymas.KasosId, uzsakymoSuma);
                uzsakymuAtaskaita.Add(ataskaitosUzsakymas);
            }
            List<UzsakymuAtaskaita> sortedUzsakymuAtaskaita = uzsakymuAtaskaita.OrderBy(x => x.Laikas).ToList();
            return sortedUzsakymuAtaskaita;
        }
        public List<UzsakymuAtaskaita> GeneruotiUzsakymuAtaskaitaPagalKasa(int kasa)
        {
            List<UzsakymuAtaskaita> visiUzsakymai = GeneruotiVisuUzsakymuAtaskaita();
            var kasosUzsakymai = new List<UzsakymuAtaskaita>();
            foreach (var uzsakymas in visiUzsakymai)
            {
                if (uzsakymas.KasosId == kasa)
                {
                    kasosUzsakymai.Add(uzsakymas);
                }
            }

            return kasosUzsakymai;
        }
        public List<UzsakymuAtaskaita> GeneruotiUzsakymuAtaskaitaPagalData(List<UzsakymuAtaskaita> uzsakymuAtaskaita, 
            DateTime data)
        {
            var ataskaitaPagalData = new List<UzsakymuAtaskaita>();
            foreach (var uzsakymas in uzsakymuAtaskaita)
            {
                if (uzsakymas.Laikas.Date == data)
                {
                    ataskaitaPagalData.Add(uzsakymas);
                }
            }

            return ataskaitaPagalData;
        }
        public List<PrekiuAtaskaita> GeneruotiVisuPrekiuAtaskaita()
        {
            var prekiuAtaskaita = new List<PrekiuAtaskaita>();
            List<Preke> visosPrekes = _prekiuRepozitorija.GautiVisasPrekes();
            List<Uzsakymas> visiUzsakymai = _uzsakymuRepozitorija.GautiVisusUzsakymus();
            foreach (var preke in visosPrekes)
            {
                var prekesKiekis = 0;
                var prekesSuma = 0m;                
                foreach (var uzsakymas in visiUzsakymai)
                {
                    foreach (var id in uzsakymas.PrekiuId)
                    {
                        if (preke.Id == id)
                        {
                            prekesKiekis++;
                            prekesSuma += preke.Kaina;
                        }
                    }
                }
                var ataskaitosPreke = new PrekiuAtaskaita(preke.Id, preke.KasosId, preke.Pavadinimas, prekesKiekis, prekesSuma);
                prekiuAtaskaita.Add(ataskaitosPreke);
            }

            return prekiuAtaskaita;
        }
        public List<PrekiuAtaskaita> GeneruotiPrekiuAtaskaitaPagalKasa(int kasa)
        {
            List<PrekiuAtaskaita> visosPrekes = GeneruotiVisuPrekiuAtaskaita();
            var kasosPrekes = new List<PrekiuAtaskaita>();
            foreach (var preke in visosPrekes)
            {
                if (preke.KasosId == kasa)
                {
                    kasosPrekes.Add(preke);
                }
            }

            return kasosPrekes;
        }
        public List<PrekiuAtaskaita> GeneruotiPrekiuAtaskaitaPagalData(DateTime data)
        {
            var prekiuAtaskaita = new List<PrekiuAtaskaita>();
            List<Preke> visosPrekes = _prekiuRepozitorija.GautiVisasPrekes();
            List<Uzsakymas> visiUzsakymai = _uzsakymuRepozitorija.GautiVisusUzsakymus();
            foreach (var preke in visosPrekes)
            {
                var prekesKiekis = 0;
                var prekesSuma = 0m;
                foreach (var uzsakymas in visiUzsakymai)
                {
                    if (uzsakymas.Laikas.Date == data)
                    {
                        foreach (var id in uzsakymas.PrekiuId)
                        {
                            if (preke.Id == id)
                            {
                                prekesKiekis++;
                                prekesSuma += preke.Kaina;
                            }
                        }
                    }
                }
                var ataskaitosPreke = new PrekiuAtaskaita(preke.Id, preke.KasosId, preke.Pavadinimas, prekesKiekis, prekesSuma);
                prekiuAtaskaita.Add(ataskaitosPreke);
            }

            return prekiuAtaskaita;
        }
        public List<PrekiuAtaskaita> GeneruotiPrekiuAtaskaitaPagalDataIrKasa(DateTime data, int kasa)
        {
            var prekiuAtaskaita = new List<PrekiuAtaskaita>();
            var visuKasuVienosDatosAtaskaita = GeneruotiPrekiuAtaskaitaPagalData(data);
            foreach (var preke in visuKasuVienosDatosAtaskaita)
            {
                if (preke.KasosId == kasa)
                {
                    prekiuAtaskaita.Add(preke);
                }
            }

            return prekiuAtaskaita;
        }
        public PrekiuAtaskaita? GeneruotiVienosPrekesAtaskaita(int prekesId)
        {
            List<PrekiuAtaskaita> visosPrekes = GeneruotiVisuPrekiuAtaskaita();
            PrekiuAtaskaita? prekesAtaskaita = visosPrekes.SingleOrDefault(x => x.Id == prekesId);

            return prekesAtaskaita;           
        }
        public PrekiuAtaskaita? GeneruotiVienosPrekesAtaskaitaPagalData(DateTime data, int prekesId)
        {
            List<PrekiuAtaskaita> visosPrekesPagalData = GeneruotiPrekiuAtaskaitaPagalData(data);
            PrekiuAtaskaita? prekesAtaskaita = visosPrekesPagalData.SingleOrDefault(x => x.Id == prekesId);

            return prekesAtaskaita;
        }
    }
}
