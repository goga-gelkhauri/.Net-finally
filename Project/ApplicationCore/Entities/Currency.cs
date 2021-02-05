using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Currency : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public float Value { get; set; }
    }
}
