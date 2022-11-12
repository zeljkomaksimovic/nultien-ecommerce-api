using NT.ECommerce.Application.DTOs.Common;
using NT.ECommerce.Application.DTOs.Customer;
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
        public int CustomerId { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
