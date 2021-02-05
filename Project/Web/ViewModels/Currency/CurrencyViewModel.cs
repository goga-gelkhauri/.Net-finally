using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class CurrencyViewModel
    {
        public IEnumerable<Currency> Currencies { get; set; }
    }
}
