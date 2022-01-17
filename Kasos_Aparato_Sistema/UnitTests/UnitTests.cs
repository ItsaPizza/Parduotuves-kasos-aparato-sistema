using Kasos_Aparatu_Sistema;
using Kasos_Aparatu_Sistema.AtaskaituModeliai;
using Kasos_Aparatu_Sistema.Modeliai;
using Kasos_Aparatu_Sistema.Repozitorijos;
using NUnit.Framework;


namespace UnitTests
{
    public class Tests
    {        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VisuUzsakymuAtaskaita()
        {
            var kasosAparatuRepozitorija = new KasosAparatuRepozitorija();
            var prekiuRepozitorija = new PrekiuRepozitorija();

            int expectedValue = 50;

            var uzsakymuRepozitorija = new UzsakymuRepozitorija(prekiuRepozitorija, kasosAparatuRepozitorija, expectedValue);
            var reportGenerator = new ReportGenerator(kasosAparatuRepozitorija, prekiuRepozitorija, uzsakymuRepozitorija);

            var uzsakymuAtaskaita = reportGenerator.GeneruotiVisuUzsakymuAtaskaita();

            int actualValue = uzsakymuAtaskaita.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [Test]
        public void GautiPrekesPavadinima()
        {
            var prekiuRepozitorija = new PrekiuRepozitorija();

            string expectedValue = "Sonine";
            Preke? preke = prekiuRepozitorija.GautiPreke(1);
            string actualValue = preke.Pavadinimas;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [Test]
        public void GautiKasosAparatoPavadinima()
        {
            var kasosAparatuRepozitorija = new KasosAparatuRepozitorija();

            string expectedValue = "Muzikos instrumentų prekių kasa";
            var kasosAparatas =  kasosAparatuRepozitorija.GautiKasosAparata(3);
            string actualValue = kasosAparatas.Pavadinimas;

            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}