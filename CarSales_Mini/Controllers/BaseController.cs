using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using CarSales_Mini.BAL.Common.Model.Base;

namespace CarSales_Mini.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public void WriteServiceResult(Controller controller, ServiceResult result)
        {
            controller.TempData.Put("FeedbackResult", result);
        }
    }

    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }
}