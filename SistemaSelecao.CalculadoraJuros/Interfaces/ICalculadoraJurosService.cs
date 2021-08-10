using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecao.CalculadoraJuros.Interfaces
{
    public interface ICalculadoraJurosService
    {
        public Task<decimal> CalcularAsync(decimal valorInicial, int tempoMeses);
    }
}
