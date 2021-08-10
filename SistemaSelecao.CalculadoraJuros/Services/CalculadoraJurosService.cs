using SistemaSelecao.CalculadoraJuros.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaSelecao.CalculadoraJuros.Services
{
    public class CalculadoraJurosService : ICalculadoraJurosService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculadoraJurosService(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<decimal> CalcularAsync(decimal valorInicial, int tempoMeses)
        {
            if (valorInicial == 0 || tempoMeses == 0)
                return 0;

            var taxa = await _taxaJurosService.ObterTaxaJuros();

            if (taxa == 0)
                return 0;

            var calculoSobreTaxa = Math.Pow((double)(1 + taxa), tempoMeses);

            var valorFinal = valorInicial * (decimal)calculoSobreTaxa;

            return Truncar(valorFinal, 2);
        }

        private decimal Truncar(decimal valor, byte decimais)
        {
            var valorArredondado = Math.Round(valor, decimais);

            if (valor > 0 && valorArredondado > valor)
            {
                return valorArredondado - new decimal(1, 0, 0, false, decimais);
            }
            else if (valor < 0 && valorArredondado < valor)
            {
                return valorArredondado + new decimal(1, 0, 0, false, decimais);
            }

            return valorArredondado;
        }
    }
}
