using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class CurrencyHistory : BaseEntity, IAggregateRoot
    {
        public string OldName { get; set; }
        public string NewName { get; set; }

        public float OldValue { get; set; }
        public float NewValue { get; set; }

        public DateTime Time { get; set; }

        public ApplicationUser User { get; set; }

        public string Status { get; set; }

    }
}

