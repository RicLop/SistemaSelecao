using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaSelecao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaSelecao.Controllers
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
        public decimal Get(decimal valorInicial, int tempoMeses)
        {
            return _calculadoraJurosService.Calcular(valorInicial, tempoMeses);
        }

        [HttpGet()]
        [Route("showmethecode")]
        public string ShowMeTheCode()
        {
            return "GIT";
        }
    }
}
