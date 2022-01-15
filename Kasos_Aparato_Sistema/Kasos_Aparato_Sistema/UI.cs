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
            Console.WriteLine("Pasirinkite norimą funkciją:");
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
        public void UzsakymuLaikotarpioMenu(int kasa)
        {
            Console.WriteLine();
            List<DateTime> uzsakymuLaikai = _uzsakymuRepozitorija.GautiVisuUzsakymuLaikus();            
            Console.WriteLine($"Uzsakymai vykdyti nuo {uzsakymuLaikai.Min()} iki {uzsakymuLaikai.Max()}. Pasirinkite laikotarpi:");
            Console.WriteLine("[1] - Viso laikotarpio uzsakymai, [2] - Uzsakymai pagal diena, [3] - Grizti");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        GeneruotiUzsakymuAtaskaita(kasa);
                        int? pasirinkimas = GriztiIseiti();
                        switch (pasirinkimas)
                        {
                            case 1:
                                UzsakymuLaikotarpioMenu(kasa);
                                break;
                            case 2:
                                MainMenu();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        //////PAGAL DIENA////////
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
        public void GeneruotiUzsakymuAtaskaita(int kasa)
        {
            var reportGenerator = new ReportGenerator(_kasosAparatuRepozitorija, _prekiuRepozitorija, _uzsakymuRepozitorija);
            List<UzsakymuAtaskaitosModelis> uzsakymuAtaskaita = reportGenerator.GeneruotiVisuUzsakymuAtaskaita();
            foreach (var uzsakymas in uzsakymuAtaskaita)
            {
                if ()
                
                if (kasa == 4)
                {
                    Console.WriteLine($"Laikas: {uzsakymas.Laikas}, uzsakymo ID: {uzsakymas.UzsakymoId}, " +
                    $"kasos ID: {uzsakymas.KasosId}, uzsakymo suma: {uzsakymas.UzsakymoSuma}");
                }

            }
            ////////Sukurti .csv ir ikelti ataskaita ten jeigu uzteks laiko.///////
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
            
        }
        public int? GriztiIseiti()
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
