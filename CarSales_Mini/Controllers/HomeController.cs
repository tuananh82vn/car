using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSales_Mini.BLL.Interface;
using CarSales_Mini.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarSales_Mini.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}