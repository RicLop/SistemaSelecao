using Moq;
using SistemaSelecao.CalculadoraJuros.Services;
using SistemaSelecao.CalculadoraJuros.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SistemaSelecao.Tests
{
    public class CalculadoraJurosServiceTest
    {
        [Theory]
        [InlineData(100, 5, 105.10)]
        [InlineData(50, 10, 55.23)]
        [InlineData(120, 0, 0)]
        [InlineData(0, 5, 0)]
        public async Task CalcularAsync_DeveCalcularAsync(int valorIncial, int tempoMeses, decimal esperado)
        {
            var httpClientFactory = new Mock<ITaxaJurosService>();
            httpClientFactory.Setup(x => x.ObterTaxaJuros()).Returns(Task.FromResult(0.01M));

            var calculadora = new CalculadoraJurosService(httpClientFactory.Object);

            var valorFinal = await calculadora.CalcularAsync(valorIncial, tempoMeses);

            Assert.Equal(valorFinal, esperado);
        }
    }
}
