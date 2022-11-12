using NT.ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Domain
{
    public class Customer : BaseDomainEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
