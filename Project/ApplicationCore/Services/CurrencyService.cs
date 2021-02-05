using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IAsyncRepository<Currency> _currencyRepository;

        public CurrencyService(IAsyncRepository<Currency> currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task CreateCurrencyAsync(Currency currency)
        {
            await _currencyRepository.AddAsync(currency);
        }

        public async Task<IReadOnlyList<Currency>> ListAllAsync()
        {
            return await _currencyRepository.ListAllAsync();
        }
    }
}
