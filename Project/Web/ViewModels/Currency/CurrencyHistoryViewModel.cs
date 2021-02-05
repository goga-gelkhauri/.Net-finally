using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class CurrencyHistoryViewModel
    {
        public IEnumerable<CurrencyHistory> CurrencyHistories { get; set; }
    }
}
