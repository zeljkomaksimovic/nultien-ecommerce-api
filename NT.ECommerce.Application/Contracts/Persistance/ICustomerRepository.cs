﻿using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Contracts.Persistance
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
