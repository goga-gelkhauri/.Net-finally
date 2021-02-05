﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<CurrencyHistory> CurrencyHistory { get; set; }
    }
}
