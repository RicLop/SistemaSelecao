using SistemaSelecao.CalculadoraJuros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaSelecao.CalculadoraJuros.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly IHttpClientFactory _clientFactory;

        public TaxaJurosService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<decimal> ObterTaxaJuros()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5021/taxajuros");
            request.Headers.Add("Accept", "text/plain");

            var response = await _clientFactory.CreateClient()
                                               .SendAsync(request);

            var resposta = await response.Content.ReadAsStringAsync();

            if (!decimal.TryParse(resposta, out decimal taxa))
                return 0;

            return taxa;
        }
    }
}
