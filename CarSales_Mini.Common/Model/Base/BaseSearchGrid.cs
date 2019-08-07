using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales_Mini.Common.Model.Base
{
    public class BaseSearchGrid
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }

        public string SortColumnName
        {
            get
            {
                string columnName = string.Empty;

                if (!string.IsNullOrEmpty(this.Sort))
                {
                    columnName = this.Sort.Substring(0, this.Sort.IndexOf("-"));
                }

                return columnName;
            }
        }

        public string SortDirection
        {
            get
            {
                string direction = string.Empty;

                if (!string.IsNullOrEmpty(this.Sort))
                {
                    direction = this.Sort.Substring(this.Sort.IndexOf("-") + 1);
                }

                return direction;
            }
        }

        public bool IsDescending
        {
            get
            {
                return this.SortDirection == "desc" ? true : false;
            }
        }
       
    }
}
