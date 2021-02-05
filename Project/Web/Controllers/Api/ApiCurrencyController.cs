using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCurrencyController : ControllerBase
    {
        private readonly ICurrencyRepository _currencyRepository;
        public ApiCurrencyController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var currencies = await _currencyRepository.GetAll();
            return Ok(currencies);
        }
    }

}
