﻿using Kasos_Aparatu_Sistema.Modeliai;
using Kasos_Aparatu_Sistema.Repozitorijos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasos_Aparatu_Sistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kasosAparatuRepozitorija = new KasosAparatuRepozitorija();
            var prekiuRepozitorija = new PrekiuRepozitorija();
            var uzsakymuRepozitorija = new UzsakymuRepozitorija(prekiuRepozitorija, kasosAparatuRepozitorija, 50);

            var UI = new UI(kasosAparatuRepozitorija, prekiuRepozitorija, uzsakymuRepozitorija);
            

            List<Uzsakymas> uzsakymai = uzsakymuRepozitorija.GautiVisusUzsakymus();
            
            foreach(var uzsakymas in uzsakymai)
            {
                Console.WriteLine($"Uzsakymo numeris: {uzsakymas.Id}, uzsakymo laikas: {uzsakymas.Laikas}");
            }
            Console.ReadLine();
        }
    }
}
