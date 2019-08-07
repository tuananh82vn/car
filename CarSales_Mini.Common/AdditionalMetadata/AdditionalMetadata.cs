using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales_Mini.Common.AdditionalMetadata
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AdditionalMetadata : Attribute
    {
        #region Private properties
        public string Name { get; set; }
        public string Value { get; set; }
        #endregion

        #region Constructor
        public AdditionalMetadata(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
        #endregion
    }
}
