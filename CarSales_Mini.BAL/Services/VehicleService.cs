using CarSales_Mini.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales_Mini.BLL.Interface;

namespace CarSales_Mini.BLL.Services
{
    public class VehicleService
    {

        private readonly CarSalesDbContext _dbContext;

        public VehicleService(CarSalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        ///// <summary>    
        ///// Select All Vehicle    
        ///// </summary>
        public async Task<List<Vehicle>> GetAllAsync()
        {
            var returnObject = await _dbContext.Vehicle.Where(m => !m.IsDeleted).ToListAsync();

            if (returnObject != null)
            {
                return returnObject;
            }
            else
                return null;
        }

    }
}
