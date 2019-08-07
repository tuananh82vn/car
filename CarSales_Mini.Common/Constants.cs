using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales_Mini.Common
{
    public static class Constants
    {
        public const int UniqueIdLength = 6;

        public static class Operation
        {
            public const string Insert = "Insert";
            public const string Update = "Update";
            public const string Delete = "Delete";
            public const string Read = "Read";
        }

        public static class ControllerNames
        {
            public const string Vehicle = "Vehicle";
            public const string VehicleType = "VehicleType";
        }


        public static class ActionNames
        {
            public const string Index = "Index";
            public const string Add = "Add";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string Delete = "Delete";
        }

        public static class ViewNames
        {
            public const string Index = "Index";
            public const string Add = "Add";
            public const string Edit = "Edit";
        }

        public static class CommonMessage
        {
            public const string CreateMessage = "{0} created successfully.";
            public const string UpdateMessage = "{0} updated successfully.";
            public const string DeleteMessage = "{0} deleted successfully.";
            public const string AlreadyExist = "{0} already exist.";
            public const string ErrorMessage = "Error happened.";
        }

        public static class VehicleName
        {
            public const string Car = "Car";
            public const string Bike = "Bike";
        }

    }

}
