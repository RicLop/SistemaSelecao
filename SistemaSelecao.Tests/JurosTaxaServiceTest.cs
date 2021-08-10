using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaSelecao.TaxaJuros.Services;
using System.Collections.Generic;

namespace SistemaSelecao.Tests
{
    [TestClass]
    public class JurosTaxaServiceTest
    {
        [TestMethod]
        public void ObterTaxa_Sucesso()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"TaxaJuros", "0.01"},
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var taxaService = new TaxaJurosService(configuration);

            var valorFinal = taxaService.ObterTaxaJuros();

            Assert.AreEqual(valorFinal, 0.01M);
        }
    }
}
