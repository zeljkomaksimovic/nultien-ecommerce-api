using NT.ECommerce.Application.Models;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.DTOs.Order
{
    public interface IOrder
    {
        public int Amount { get; set; }
        public decimal AppliedDiscount { get; set; }
        public Address? Address { get; set; }
    }
}
