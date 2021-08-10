using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaSelecao.CalculadoraJuros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaSelecao.CalculadoraJuros.Controllers
{
    [ApiController]
    public class CalculadoraJurosController : ControllerBase
    {
        private readonly ICalculadoraJurosService _calculadoraJurosService;

        public CalculadoraJurosController(ICalculadoraJurosService calculadoraJurosService)
        {
            _calculadoraJurosService = calculadoraJurosService;
        }

        [HttpGet()]
        [Route("calculajuros")]
        public async Task<decimal> Get(decimal valorInicial, int tempoMeses) =>
            await _calculadoraJurosService.CalcularAsync(valorInicial, tempoMeses);

        [HttpGet()]
        [Route("showmethecode")]
        public string ShowMeTheCode() =>
            "https://github.com/RicLop/SistemaSelecao";
    }
}
