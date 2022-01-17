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
    public class UI
    {
        private KasosAparatuRepozitorija _kasosAparatuRepozitorija;
        private PrekiuRepozitorija _prekiuRepozitorija;
        private UzsakymuRepozitorija _uzsakymuRepozitorija;
        public UI(KasosAparatuRepozitorija kasosAparatuRepozitorija, 
            PrekiuRepozitorija prekiuRepozitorija, 
            UzsakymuRepozitorija uzsakymuRepozitorija)
        {
            _kasosAparatuRepozitorija = kasosAparatuRepozitorija;
            _prekiuRepozitorija = prekiuRepozitorija;
            _uzsakymuRepozitorija = uzsakymuRepozitorija;
            
        }
        public void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Kasos Aparatu Sistema v1.0");
            Console.WriteLine("Pasirinkite norimą veiksma:");
            Console.WriteLine("[1] - Ataskaitos, [2] - Prekių sąrašas, [3] - Išeiti");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        KasosMenu();
                        break;
                    case 2:
                        PrekiuSarasas();
                        break;
                    case 3:
                        CloseApp();
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        MainMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                MainMenu();
            }
        }
        public void KasosMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Pasirinkite kurių kasų ataskaitas norite matyti:");
            var pirmaKasa = _kasosAparatuRepozitorija.GautiKasosAparata(1);
            var antraKasa = _kasosAparatuRepozitorija.GautiKasosAparata(2);
            var treciaKasa = _kasosAparatuRepozitorija.GautiKasosAparata(3);

            Console.WriteLine($"[1] - {pirmaKasa.Pavadinimas}, [2] - {antraKasa.Pavadinimas}, [3] - {treciaKasa.Pavadinimas}, " +
                $"[4] - Visos kasos, [5] - Grizti");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if(result == 1 || result == 2 || result == 3 |result == 4)
                {
                    _kasosAparatuRepozitorija.PasirinktaKasa = result;
                    UzsakymuArPrekiuMenu();
                }
                else if(result == 5)
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Pasirinkimas neegzistuoja");
                    KasosMenu();
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                KasosMenu();
            }
        }
        public void UzsakymuArPrekiuMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Pasirinkite ataskaitos tipa:");
            Console.WriteLine("[1] - Uzsakymu ataskaita, [2] - Prekiu ataskaita, [3] - Grizti");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        UzsakymuLaikotarpioMenu();
                        break;
                    case 2:
                        VisuArVienosPrekesMenu();
                        break;
                    case 3:
                        KasosMenu();
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        UzsakymuArPrekiuMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                UzsakymuArPrekiuMenu();
            }
        }
        private void VisuArVienosPrekesMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Pasirinkite visu prekiu ar vienos prekes ataskaita:");
            Console.WriteLine("[1] - Visu prekiu, [2] - Vienos prekes, [3] - Grizti");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        PrekiuLaikotarpioMenu();
                        break;
                    case 2:
                        NurodytiPrekesIdMenu();
                        PrekėsLaikotarpioMenu();
                        break;
                    case 3:
                        UzsakymuArPrekiuMenu();
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        VisuArVienosPrekesMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                VisuArVienosPrekesMenu();
            }
        }
        public void NurodytiPrekesIdMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Nurodykite norimos prekes ID:");
            if (int.TryParse(Console.ReadLine(), out int prekesId))
            {
                if (prekesId > 0 && prekesId < _prekiuRepozitorija.GautiVisasPrekes().Count+1)
                {
                    _prekiuRepozitorija.PasirinktaPreke = prekesId;
                }
                else
                {
                    Console.WriteLine("Pasirinktas prekes ID neegzistuoja");
                    VisuArVienosPrekesMenu();
                }
                                   
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                VisuArVienosPrekesMenu();
            }
        }
        private void PrekėsLaikotarpioMenu()
        {
            LaikotarpioMenu();
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        GeneruotiPrekėsAtaskaita();
                        int? pasirinkimas = GriztiIseiti();
                        switch (pasirinkimas)
                        {
                            case 1:
                                PrekėsLaikotarpioMenu();
                                break;
                            case 2:
                                MainMenu();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        DienosPasirinkimoMenuVienaiPrekei();
                        break;
                    case 3:
                        VisuArVienosPrekesMenu();
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        PrekiuLaikotarpioMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                PrekiuLaikotarpioMenu();
            }
        }
        public void GeneruotiPrekėsAtaskaita()
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            PrekiuAtaskaita? prekesAtaskaita = reportGenerator.GeneruotiVienosPrekesAtaskaita(_prekiuRepozitorija.PasirinktaPreke);
            if (prekesAtaskaita != null)
            {
                SpausdintiVienosPrekesAtaskaita(prekesAtaskaita);
            }
            else
            {
                Console.WriteLine("Prekes ataskaita negalima");
                PrekėsLaikotarpioMenu();
            }
            
        }
        private void UzsakymuLaikotarpioMenu()
        {
            LaikotarpioMenu();
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        GeneruotiUzsakymuAtaskaita();
                        UzsakymoIdMenu();
                        
                        break;
                    case 2:
                        DienosPasirinkimoMenuUzsakymams();
                        break;
                    case 3:
                        UzsakymuArPrekiuMenu();
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        UzsakymuLaikotarpioMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                UzsakymuLaikotarpioMenu();
            }
        }
        private void PrekiuLaikotarpioMenu()
        {
            LaikotarpioMenu();
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        GeneruotiPrekiuAtaskaita();
                        int? pasirinkimas = GriztiIseiti();
                        switch (pasirinkimas)
                        {
                            case 1:
                                PrekiuLaikotarpioMenu();
                                break;
                            case 2:
                                MainMenu();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        DienosPasirinkimoMenuPrekems();
                        break;
                    case 3:
                        VisuArVienosPrekesMenu();
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        PrekiuLaikotarpioMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                PrekiuLaikotarpioMenu();
            }
        }
        private void GeneruotiPrekiuAtaskaita()
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            var prekiuAtaskaita = new List<PrekiuAtaskaita>(); 
            if (_kasosAparatuRepozitorija.PasirinktaKasa == 1 || 
                _kasosAparatuRepozitorija.PasirinktaKasa == 2 || 
                _kasosAparatuRepozitorija.PasirinktaKasa == 3)
            {
                prekiuAtaskaita = reportGenerator.GeneruotiPrekiuAtaskaitaPagalKasa(_kasosAparatuRepozitorija.PasirinktaKasa);                
            }
            else if (_kasosAparatuRepozitorija.PasirinktaKasa == 4)
            {
                prekiuAtaskaita = reportGenerator.GeneruotiVisuPrekiuAtaskaita();
            }
            SpausdintiPrekiuAtaskaita(prekiuAtaskaita);
        }
        private void LaikotarpioMenu()
        {
            Console.WriteLine();
            List<DateTime> uzsakymuLaikai = _uzsakymuRepozitorija.GautiVisuUzsakymuLaikus();
            Console.WriteLine($"Uzsakymai vykdyti nuo {uzsakymuLaikai.Min()} iki {uzsakymuLaikai.Max()}. Pasirinkite laikotarpi:");
            Console.WriteLine("[1] - Viso laikotarpio uzsakymai, [2] - Uzsakymai pagal diena, [3] - Grizti");
        }
        private void DienosPasirinkimoMenuVienaiPrekei()
        {
            Console.WriteLine();
            Console.WriteLine("Iveskite norima data");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
            {
                GeneruotiVienosPrekesAtaskaitaPagalData(data);                
                int? pasirinkimas = GriztiIseiti();
                switch (pasirinkimas)
                {
                    case 1:
                        PrekėsLaikotarpioMenu();
                        break;
                    case 2:
                        MainMenu();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra datos formato.");
                PrekiuLaikotarpioMenu();
            }
        }
        private void DienosPasirinkimoMenuPrekems()
        {
            Console.WriteLine();
            Console.WriteLine("Iveskite norima data");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
            {
                GeneruotiPrekiuAtaskaitaPagalData(data);
                int? pasirinkimas = GriztiIseiti();
                switch (pasirinkimas)
                {
                    case 1:
                        PrekiuLaikotarpioMenu();
                        break;
                    case 2:
                        MainMenu();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra datos formato.");
                PrekiuLaikotarpioMenu();
            }
        }
        private void DienosPasirinkimoMenuUzsakymams()
        {
            Console.WriteLine();
            Console.WriteLine("Iveskite norima data");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
            {
                GeneruotiUzsakymuAtaskaitaPagalData(data);
                UzsakymoIdMenu();
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra datos formato.");
                UzsakymuLaikotarpioMenu();
            }

        }
        private void GeneruotiVienosPrekesAtaskaitaPagalData(DateTime data)
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            PrekiuAtaskaita? prekesAtaskaita = reportGenerator.GeneruotiVienosPrekesAtaskaitaPagalData(data, _prekiuRepozitorija.PasirinktaPreke);
            if (prekesAtaskaita != null)
            {
                SpausdintiVienosPrekesAtaskaita(prekesAtaskaita);
            }
            else
            {
                Console.WriteLine("Prekes ataskaita negalima");
                PrekėsLaikotarpioMenu();
            }
        }
        private void GeneruotiPrekiuAtaskaitaPagalData(DateTime data)
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            var prekiuAtaskaita = new List<PrekiuAtaskaita>();
            if (_kasosAparatuRepozitorija.PasirinktaKasa == 1 || 
                _kasosAparatuRepozitorija.PasirinktaKasa == 2 ||
                _kasosAparatuRepozitorija.PasirinktaKasa == 3)
            {
                prekiuAtaskaita = reportGenerator.GeneruotiPrekiuAtaskaitaPagalDataIrKasa(data, _kasosAparatuRepozitorija.PasirinktaKasa);
            }
            else if (_kasosAparatuRepozitorija.PasirinktaKasa == 4)
            {
                prekiuAtaskaita = reportGenerator.GeneruotiPrekiuAtaskaitaPagalData(data);
            }
            SpausdintiPrekiuAtaskaita(prekiuAtaskaita);
        }
        private void GeneruotiUzsakymuAtaskaitaPagalData(DateTime data)
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            var uzsakymuAtaskaita = new List<UzsakymuAtaskaitosModelis>();
            var pirmineAtaskaita = new List<UzsakymuAtaskaitosModelis>();
            if (_kasosAparatuRepozitorija.PasirinktaKasa == 1 || 
                _kasosAparatuRepozitorija.PasirinktaKasa == 2 ||
                _kasosAparatuRepozitorija.PasirinktaKasa == 3)
            {
                pirmineAtaskaita = reportGenerator.GeneruotiUzsakymuAtaskaitaPagalKasa(_kasosAparatuRepozitorija.PasirinktaKasa);
            }
            else if (_kasosAparatuRepozitorija.PasirinktaKasa == 4)
            {
                pirmineAtaskaita = reportGenerator.GeneruotiVisuUzsakymuAtaskaita();
            }
            uzsakymuAtaskaita = reportGenerator.GeneruotiUzsakymuAtaskaitaPagalData(pirmineAtaskaita, data);
            SpausdintiUzsakymuAtaskaita(uzsakymuAtaskaita);

            ////////Sukurti .csv ir ikelti ataskaita ten jeigu uzteks laiko.///////
        }
        private void UzsakymoIdMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Pasirinkite norimą veiksma:");
            Console.WriteLine("[1] - Ziureti uzsakyma pagal ID, [2] - Grizti, [3] - Grizti i pagrindini Meniu");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        IvestiUzsakymoIdMenu();
                        int? pasirinkimas = GriztiIseiti();
                        switch (pasirinkimas)
                        {
                            case 1:
                                UzsakymoIdMenu();
                                break;
                            case 2:
                                MainMenu();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        UzsakymuLaikotarpioMenu();
                        break;
                    case 3:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        UzsakymoIdMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                UzsakymoIdMenu();
            }
        }
        private void IvestiUzsakymoIdMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Iveskite uzsakymo ID:");
            if (Guid.TryParse(Console.ReadLine(), out Guid result))
            {
                var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
                reportGenerator.RodytiUzsakymaPagalId(result);
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra Guid tipo.");
                UzsakymoIdMenu();
            }
        }
        private void GeneruotiUzsakymuAtaskaita()
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            var uzsakymuAtaskaita = new List<UzsakymuAtaskaitosModelis>();
            if (_kasosAparatuRepozitorija.PasirinktaKasa == 1 ||
                _kasosAparatuRepozitorija.PasirinktaKasa == 2 ||
                _kasosAparatuRepozitorija.PasirinktaKasa == 3)
            {
                uzsakymuAtaskaita = reportGenerator.GeneruotiUzsakymuAtaskaitaPagalKasa(_kasosAparatuRepozitorija.PasirinktaKasa);               
            }
            else if (_kasosAparatuRepozitorija.PasirinktaKasa == 4)
            {
                uzsakymuAtaskaita = reportGenerator.GeneruotiVisuUzsakymuAtaskaita();                
            }

            SpausdintiUzsakymuAtaskaita(uzsakymuAtaskaita);

            ////////Sukurti .csv ir ikelti ataskaita ten jeigu uzteks laiko.///////
        }
        private void SpausdintiVienosPrekesAtaskaita(PrekiuAtaskaita prekesAtaskaita)
        {
            Console.WriteLine();
            Console.WriteLine($"Prekes ID: {prekesAtaskaita.Id}, kasos ID: {prekesAtaskaita.KasosId}, " +
                $"prekes pavadinimas: {prekesAtaskaita.Pavadinimas}, " +
                    $"kieks: {prekesAtaskaita.Kiekis}, suma: {prekesAtaskaita.Suma}");

        }
        private void SpausdintiPrekiuAtaskaita(List<PrekiuAtaskaita> prekiuAtaskaita)
        {
            Console.WriteLine();
            decimal prekiuSuma = 0m;
            foreach (var preke in prekiuAtaskaita)
            {               
                Console.WriteLine($"Prekes ID: {preke.Id}, kasos ID: {preke.KasosId}, prekes pavadinimas: {preke.Pavadinimas}, " +
                    $"kieks: {preke.Kiekis}, suma: {preke.Suma}");
                prekiuSuma += preke.Suma;
            }
            if (prekiuAtaskaita.Count == 0)
            {
                Console.WriteLine("Uzsakymu nerasta.");
            }
            else
            {
                Console.WriteLine($"Bendra prekiu suma: {prekiuSuma}");
            }
        }
        private void SpausdintiUzsakymuAtaskaita(List<UzsakymuAtaskaitosModelis> uzsakymuAtaskaita)
        {
            Console.WriteLine();
            foreach (var uzsakymas in uzsakymuAtaskaita)
            {
                Console.WriteLine($"Laikas: {uzsakymas.Laikas}, uzsakymo ID: {uzsakymas.UzsakymoId}, " +
                $"kasos ID: {uzsakymas.KasosId}, uzsakymo suma: {uzsakymas.UzsakymoSuma}");
            }
            if (uzsakymuAtaskaita.Count == 0)
            {
                Console.WriteLine("Uzsakymu nerasta.");
            }
        }
        public void PrekiuSarasas()
        {
            List<Preke> prekes = _prekiuRepozitorija.GautiVisasPrekes();
            foreach (Preke preke in prekes)
            {
                Console.WriteLine($"Prekės ID: {preke.Id}, kasos ID: {preke.KasosId}, prekė: {preke.Pavadinimas}, kaina: {preke.Kaina}");
            }
            int? pasirinkimas = GriztiIseiti();
            switch (pasirinkimas)
            {
                case 1:
                case 2:
                    MainMenu();
                    break;
                default:
                    break;
            }

        }
        public void CloseApp()
        {
            Console.WriteLine("Programa isjungiama");
            Environment.Exit(0);
        }
        private int? GriztiIseiti()
        {
            Console.WriteLine();
            Console.WriteLine("Pasirinkite norimą funkciją:");
            Console.WriteLine("[1] - Grįžti, [2] - Grįžti į pagrindinį Meniu, [3] - Išeiti");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        return 1;                       
                    case 2:
                        return 2;
                    case 3:
                        CloseApp();
                        return null;
                    default:
                        Console.WriteLine("Toks pasirinkimas neegzistuoja");
                        int? output = GriztiIseiti();
                        if (output != null)
                        {
                            switch (output)
                            {
                                case 1:
                                    return 1;
                                case 2:
                                    return 2;
                                default:
                                    break;
                            }
                        }
                        return null; 
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                var output = GriztiIseiti();
                if (output != null)
                {
                    switch (output)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        default:
                            break;
                    }
                }
                return null;
            }
        }
    }

}
