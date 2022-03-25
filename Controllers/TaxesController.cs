using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using IMC_codeChallenge.Helper;
using IMC_codeChallenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IMC_codeChallenge.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly ITaxService _taxService;
        public TaxesController(IOptions<AppSettings> appSettings, ITaxService taxService)
        {
            _appSettings = appSettings;
            _taxService = taxService;
        }

       [HttpGet]
       [Route("GetTaxRate")]
        public async Task<IActionResult> GetTaxRate(string zipCode)
        {
            var apiKey = _appSettings.Value?.TaxJar.key;
            if (string.IsNullOrEmpty(zipCode))
            {
                return BadRequest("Zip Code required");
            }

            var data = await _taxService.GetTaxRatesForLocation(apiKey, zipCode);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.rate);
        }

        [HttpGet]
        [Route("Orders")]
        public async Task<IActionResult> Orders(string zipCode)
        {
            var apiKey = _appSettings.Value?.TaxJar.key;
            if (string.IsNullOrEmpty(zipCode))
            {
                return BadRequest("Zip Code required");
            }

            var taxData = await _taxService.GetTaxRatesForLocation(apiKey, zipCode);
            var order = OrderHelper.GenerateOrder();
            order.taxRate = taxData.rate.combined_rate;
            order.total = order.subTotal + (order.subTotal * order.taxRate);
            return Ok(order);
        }
    }
}