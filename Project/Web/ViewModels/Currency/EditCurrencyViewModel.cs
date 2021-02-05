using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class EditCurrencyViewModel
    {
        public Currency Currency { get; set; }
        public Currency Old { get; set; }
    }
}
