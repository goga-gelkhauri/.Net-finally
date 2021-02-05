using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICurrencyService
    {
        Task CreateCurrencyAsync(Currency currency);
        Task<IReadOnlyList<Currency>> ListAllAsync();
    }
}
