using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarSales_Mini.Common.Helper;

namespace CarSales_Mini.BLL.Helpers
{
    public static class DropdownHelper
    {

        private static SelectListItem EmptyListItem = new SelectListItem
        {
            Value = "",
            Text = "Select"
        };
        
    }
}
