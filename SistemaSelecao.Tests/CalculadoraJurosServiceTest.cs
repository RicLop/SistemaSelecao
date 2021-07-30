using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaSelecao.Interfaces;
using SistemaSelecao.Services;

namespace SistemaSelecao.Tests
{
    [TestClass]
    public class CalculadoraJurosServiceTest
    {
        [TestMethod]
        public void Calcular_DadoCorretos_Sucesso()
        {
            var valorIncial = 100;
            var tempoMeses = 5;

            var taxaJurosService = new Mock<ITaxaJurosService>();
            taxaJurosService.Setup(x => x.ObterTaxaJuros()).Returns(0.01M);

            var calculadora = new CalculadoraJurosService(taxaJurosService.Object);

            var valorFinal = calculadora.Calcular(valorIncial, tempoMeses);

            Assert.AreEqual(valorFinal, 105.10M);
        }

        [TestMethod]
        public void Calcular_FaltandoMês_Falha()
        {
            var valorIncial = 100;
            var tempoMeses = 0;

            var taxaJurosService = new Mock<ITaxaJurosService>();
            taxaJurosService.Setup(x => x.ObterTaxaJuros()).Returns(0.01M);

            var calculadora = new CalculadoraJurosService(taxaJurosService.Object);

            var valorFinal = calculadora.Calcular(valorIncial, tempoMeses);

            Assert.AreEqual(valorFinal, 0);
        }

        [TestMethod]
        public void Calcular_FaltandoValorInicial_Falha()
        {
            var valorIncial = 0;
            var tempoMeses = 5;

            var taxaJurosService = new Mock<ITaxaJurosService>();
            taxaJurosService.Setup(x => x.ObterTaxaJuros()).Returns(0.01M);

            var calculadora = new CalculadoraJurosService(taxaJurosService.Object);

            var valorFinal = calculadora.Calcular(valorIncial, tempoMeses);

            Assert.AreEqual(valorFinal, 0);
        }
    }
}
