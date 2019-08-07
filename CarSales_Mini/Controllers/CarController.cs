using CarSales_Mini.BAL.Common.Model.Base;
using CarSales_Mini.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CarSales_Mini.BLL.Interface;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using static CarSales_Mini.Common.Constants;
using CarSales_Mini.BLL.Services;
using CarSales_Mini.Common.Model;
using Microsoft.Extensions.Options;
using System.Linq;

namespace CarSales_Mini.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class CarController : BaseController
    {
        private IEnumerable<IVehicleService> _vehicleService { get; set; }
        private AppSettings _appSettings { get; set; }
        private IVehicleService _carService { get; set; }

        public CarController(IEnumerable<IVehicleService> vehicleService, IOptions<AppSettings> appSettings)
        {
            _vehicleService = vehicleService;
            _appSettings = appSettings.Value;

            _carService = _vehicleService.FirstOrDefault(h => h.CurrentName == _appSettings.CarController);
        }

        //GET api
        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> GetCarListAsync()
        {
            var cars = await _carService.GetAllAsync();

            return cars;
        }

        //POST api/values
        [HttpPost]
        public async Task<IActionResult> PostCar([FromBody]Car car)
        {
            var serviceResult = new ServiceResult();

            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var result = await _carService.AddAsync(car);

            if (result.Id > 0)
            {
                serviceResult.IsSuccess = (true);
                serviceResult.Info.Add(string.Format(Common.Constants.CommonMessage.CreateMessage, VehicleName.Car));

            }
            else
            {
                serviceResult.IsSuccess = (false);
                serviceResult.Errors.Add(string.Format(Common.Constants.CommonMessage.ErrorMessage));
            }

            return Json(serviceResult);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var serviceResult = new ServiceResult();

            var result = await _carService.DeleteAsync(id);
            if (result)
            {
                serviceResult.IsSuccess = (true);
                serviceResult.Info.Add(string.Format(Common.Constants.CommonMessage.DeleteMessage, VehicleName.Car));
            }
            else
            {
                serviceResult.IsSuccess = (false);
                serviceResult.Errors.Add(string.Format(Common.Constants.CommonMessage.ErrorMessage));
            }

            return Json(serviceResult);
        }

        //PUT: api/car
        [HttpPut]
        public async Task<IActionResult> PutCar([FromBody]Car car)
        {
            var serviceResult = new ServiceResult();

            var result = await _carService.EditAsync(car);

            if (result)
            {
                serviceResult.IsSuccess = (true);
                serviceResult.Info.Add(string.Format(Common.Constants.CommonMessage.DeleteMessage, VehicleName.Car));
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
