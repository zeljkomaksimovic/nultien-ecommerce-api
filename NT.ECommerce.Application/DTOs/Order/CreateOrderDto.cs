using NT.ECommerce.Application.DTOs.Common;
using NT.ECommerce.Application.DTOs.Order;
using NT.ECommerce.Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.DTOs.Order
{
    public class CreateOrderDto : IOrder
    {
        public int Amount { get; set; }
        public decimal AppliedDiscount { get; set; }
        public Address? Address { get; set; }
    }
}
