using Microsoft.Extensions.Configuration;
using SistemaSelecao.TaxaJuros.Interfaces;

namespace SistemaSelecao.TaxaJuros.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly IConfiguration _configuracao;

        public TaxaJurosService(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public decimal ObterTaxaJuros()
        {
            return _configuracao.GetValue<decimal>("TaxaJuros");
        }
    }
}
