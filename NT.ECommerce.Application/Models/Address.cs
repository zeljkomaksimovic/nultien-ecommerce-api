using NT.ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Models
{
    public class Address
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
    }
}
