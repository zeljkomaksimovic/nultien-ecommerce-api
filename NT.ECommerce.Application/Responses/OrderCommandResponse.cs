using NT.ECommerce.Application.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Responses
{
    public class OrderCommandResponse : BaseCommandResponse
    {
        public decimal? TotalAmount { get; set; }
        public decimal? AppliedDiscount { get; set; }

    }
}
