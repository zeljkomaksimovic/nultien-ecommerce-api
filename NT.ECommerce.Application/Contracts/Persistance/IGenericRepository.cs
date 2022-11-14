﻿using NT.ECommerce.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id); 
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
    }
}
