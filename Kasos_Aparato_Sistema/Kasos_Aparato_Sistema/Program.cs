using Kasos_Aparatu_Sistema.Modeliai;
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
            var uzsakymuRepozitorija = new UzsakymuRepozitorija(prekiuRepozitorija, kasosAparatuRepozitorija, 500);

            var UI = new UI(kasosAparatuRepozitorija, prekiuRepozitorija, uzsakymuRepozitorija);

            UI.MainMenu();
            
        }
    }
}
