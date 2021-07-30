using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecao.Interfaces
{
    public interface ICalculadoraJurosService
    {
        public decimal Calcular(decimal valorInicial, int tempoMeses);
    }
}
