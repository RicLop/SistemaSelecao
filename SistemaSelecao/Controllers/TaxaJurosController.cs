using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SistemaSelecao.Interfaces;
using System.Globalization;

namespace SistemaSelecao.Controllers
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
        public decimal Get()
        {
            return _taxaJurosService.ObterTaxaJuros();
        }        
    }
}
