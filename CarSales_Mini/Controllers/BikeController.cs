using CarSales_Mini.BAL.Common.Model.Base;
using CarSales_Mini.BLL.Services;
using CarSales_Mini.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using CarSales_Mini.BLL.Interface;
using System.Collections.Generic;
using static CarSales_Mini.Common.Constants;
using Microsoft.AspNetCore.Cors;
using CarSales_Mini.Common.Model;
using Microsoft.Extensions.Options;
using System.Linq;

namespace CarSales_Mini.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class BikeController : BaseController
    {
        private IEnumerable<IVehicleService> _vehicleService { get; set; }
        private AppSettings _appSettings { get; set; }
        private IVehicleService _bikeService { get; set; }

        public BikeController(IEnumerable<IVehicleService> vehicleService, IOptions<AppSettings> appSettings)
        {
            _vehicleService = vehicleService;
            _appSettings = appSettings.Value;

            _bikeService = _vehicleService.FirstOrDefault(h => h.CurrentName == _appSettings.BikeController);
        }

        //GET api
        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> GetBikeListAsync()
        {
            var bikes = await _bikeService.GetAllAsync();

            return bikes;
        }

        //POST api/values
        [HttpPost]
        public async Task<IActionResult> PostBike([FromBody]Bike bike)
        {
            var serviceResult = new ServiceResult();

            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var result = await _bikeService.AddAsync(bike);
            if (result.Id > 0)
            {
                serviceResult.IsSuccess = (true);
                serviceResult.Info.Add(string.Format(Common.Constants.CommonMessage.CreateMessage, VehicleName.Bike));

            }
            else
            {
                serviceResult.IsSuccess = (false);
                serviceResult.Errors.Add(string.Format(Common.Constants.CommonMessage.ErrorMessage));
            }

            return Json(serviceResult);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBike(int id)
        {
            var serviceResult = new ServiceResult();

            var result = await _bikeService.DeleteAsync(id);
            if (result)
            {
                serviceResult.IsSuccess = (true);
                serviceResult.Info.Add(string.Format(Common.Constants.CommonMessage.DeleteMessage, VehicleName.Bike));
            }
            else
            {
                serviceResult.IsSuccess = (false);
                serviceResult.Errors.Add(string.Format(Common.Constants.CommonMessage.ErrorMessage));
            }

            return Json(serviceResult);
        }

        //PUT: api/bike
        [HttpPut]
        public async Task<IActionResult> PutBike([FromBody]Bike bike)
        {
            var serviceResult = new ServiceResult();

            var result = await _bikeService.EditAsync(bike);

            if (result)
            {
                serviceResult.IsSuccess = (true);
                serviceResult.Info.Add(string.Format(Common.Constants.CommonMessage.DeleteMessage, VehicleName.Bike));
            }
            else
            {
                serviceResult.IsSuccess = (false);
                serviceResult.Errors.Add(string.Format(Common.Constants.CommonMessage.ErrorMessage));
            }

            return Json(serviceResult);
        }
    }
}
