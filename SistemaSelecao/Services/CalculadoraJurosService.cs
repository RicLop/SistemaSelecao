using SistemaSelecao.Interfaces;
using System;

namespace SistemaSelecao.Services
{
    public class CalculadoraJurosService : ICalculadoraJurosService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculadoraJurosService(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public decimal Calcular(decimal valorInicial, int tempoMeses)
        {
            if (valorInicial == 0 || tempoMeses == 0)
                return 0;

            var taxa = _taxaJurosService.ObterTaxaJuros();

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
