using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SistemaSelecao.TaxaJuros.Interfaces;
using System.Globalization;

namespace SistemaSelecao.TaxaJuros.Controllers
{
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosController(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        [HttpGet]
        [Route("taxajuros")]
        public decimal Get() => 
            _taxaJurosService.ObterTaxaJuros();        
    }
}
