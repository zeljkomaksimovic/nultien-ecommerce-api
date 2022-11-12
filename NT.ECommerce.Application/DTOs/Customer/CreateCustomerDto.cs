using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.DTOs.Customer
{
    public class CreateCustomerDto : ICustomerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
