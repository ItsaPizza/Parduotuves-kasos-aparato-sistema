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

            MainMenu();
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
                    UzsakymuArPrekiuMenu(result);
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
        public void UzsakymuArPrekiuMenu(int kasa)
        {
            Console.WriteLine();
            Console.WriteLine("Pasirinkite ataskaitos tipa:");
            Console.WriteLine("[1] - Uzsakymu ataskaita, [2] - Prekiu ataskaita, [3] - Grizti");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        UzsakymuLaikotarpioMenu(kasa);
                        break;
                    case 2:
                        ////////////Prekiu Ataskaita/////////////
                        VisuArVienosPrekesMenu(kasa);
                        break;
                    case 3:
                        KasosMenu();
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        UzsakymuArPrekiuMenu(kasa);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                UzsakymuArPrekiuMenu(kasa);
            }
        }
        private void VisuArVienosPrekesMenu(int kasa)
        {
            Console.WriteLine();
            Console.WriteLine("Pasirinkite visu prekiu ar vienos prekes ataskaita:");
            Console.WriteLine("[1] - Visu prekiu, [2] - Vienos prekes, [3] - Grizti");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        PrekiuLaikotarpioMenu(kasa);
                        break;
                    case 2:
                        ////////Vienos prekes ataskaita//////

                        break;
                    case 3:
                        UzsakymuArPrekiuMenu(kasa);
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        VisuArVienosPrekesMenu(kasa);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                VisuArVienosPrekesMenu(kasa);
            }
        }
        private void UzsakymuLaikotarpioMenu(int kasa)
        {
            LaikotarpioMenu();
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        GeneruotiUzsakymuAtaskaita(kasa);
                        UzsakymoIdMenu(kasa);
                        
                        break;
                    case 2:
                        DienosPasirinkimoMenuUzsakymams(kasa);
                        break;
                    case 3:
                        UzsakymuArPrekiuMenu(kasa);
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        UzsakymuLaikotarpioMenu(kasa);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                UzsakymuLaikotarpioMenu(kasa);
            }
        }
        private void PrekiuLaikotarpioMenu(int kasa)
        {
            LaikotarpioMenu();
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        GeneruotiPrekiuAtaskaita(kasa);
                        int? pasirinkimas = GriztiIseiti();
                        switch (pasirinkimas)
                        {
                            case 1:
                                PrekiuLaikotarpioMenu(kasa);
                                break;
                            case 2:
                                MainMenu();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        DienosPasirinkimoMenuPrekems(kasa);
                        break;
                    case 3:
                        VisuArVienosPrekesMenu(kasa);
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        PrekiuLaikotarpioMenu(kasa);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                PrekiuLaikotarpioMenu(kasa);
            }
        }
        private void GeneruotiPrekiuAtaskaita(int kasa)
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            var prekiuAtaskaita = new List<PrekiuAtaskaita>(); 
            if (kasa == 1 || kasa == 2 | kasa == 3)
            {
                prekiuAtaskaita = reportGenerator.GeneruotiPrekiuAtaskaitaPagalKasa(kasa);                
            }
            else if (kasa == 4)
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
        private void DienosPasirinkimoMenuPrekems(int kasa)
        {
            Console.WriteLine();
            Console.WriteLine("Iveskite norima data");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
            {
                
                //GeneruotiUzsakymuAtaskaitaPagalData(result, kasa);
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra datos formato.");
                PrekiuLaikotarpioMenu(kasa);
            }

        }
        private void DienosPasirinkimoMenuUzsakymams(int kasa)
        {
            Console.WriteLine();
            Console.WriteLine("Iveskite norima data");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
            {
                GeneruotiUzsakymuAtaskaitaPagalData(result, kasa);
                UzsakymoIdMenu(kasa);
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra datos formato.");
                UzsakymuLaikotarpioMenu(kasa);
            }

        }
        private void GeneruotiPrekiuAtaskaitaPagalData(DateTime data, int kasa)
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            var prekiuAtaskaita = new List<PrekiuAtaskaita>();
            if (kasa == 1 || kasa == 2 | kasa == 3)
            {
                prekiuAtaskaita = //Sukurti ataskaita pagal data IR kasa
            }
            else if (kasa == 4)
            {
                prekiuAtaskaita = reportGenerator.GeneruotiPrekiuAtaskaitaPagalData(data);
            }
        }
        private void GeneruotiUzsakymuAtaskaitaPagalData(DateTime data, int kasa)
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            var uzsakymuAtaskaita = new List<UzsakymuAtaskaitosModelis>();
            var pirmineAtaskaita = new List<UzsakymuAtaskaitosModelis>();
            if (kasa == 1 || kasa == 2 | kasa == 3)
            {
                pirmineAtaskaita = reportGenerator.GeneruotiUzsakymuAtaskaitaPagalKasa(kasa);
            }
            else if (kasa == 4)
            {
                pirmineAtaskaita = reportGenerator.GeneruotiVisuUzsakymuAtaskaita();
            }
            uzsakymuAtaskaita = reportGenerator.GeneruotiUzsakymuAtaskaitaPagalData(pirmineAtaskaita, data);
            SpausdintiUzsakymuAtaskaita(uzsakymuAtaskaita);

            ////////Sukurti .csv ir ikelti ataskaita ten jeigu uzteks laiko.///////
        }
        private void UzsakymoIdMenu(int kasa)
        {
            Console.WriteLine();
            Console.WriteLine("Pasirinkite norimą veiksma:");
            Console.WriteLine("[1] - Ziureti uzsakyma pagal ID, [2] - Grizti, [3] - Grizti i pagrindini Meniu");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        IvestiUzsakymoIdMenu(kasa);
                        int? pasirinkimas = GriztiIseiti();
                        switch (pasirinkimas)
                        {
                            case 1:
                                UzsakymoIdMenu(kasa);
                                break;
                            case 2:
                                MainMenu();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        UzsakymuLaikotarpioMenu(kasa);
                        break;
                    case 3:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Pasirinkimas neegzistuoja");
                        UzsakymoIdMenu(kasa);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ivestas pasirinkimas nėra skaičius.");
                UzsakymoIdMenu(kasa);
            }
        }
        private void IvestiUzsakymoIdMenu(int kasa)
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
                UzsakymoIdMenu(kasa);
            }
        }
        private void GeneruotiUzsakymuAtaskaita(int kasa)
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            var uzsakymuAtaskaita = new List<UzsakymuAtaskaitosModelis>();
            if (kasa == 1 || kasa == 2 | kasa == 3)
            {
                uzsakymuAtaskaita = reportGenerator.GeneruotiUzsakymuAtaskaitaPagalKasa(kasa);               
            }
            else if (kasa == 4)
            {
                uzsakymuAtaskaita = reportGenerator.GeneruotiVisuUzsakymuAtaskaita();                
            }

            SpausdintiUzsakymuAtaskaita(uzsakymuAtaskaita);

            ////////Sukurti .csv ir ikelti ataskaita ten jeigu uzteks laiko.///////
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
