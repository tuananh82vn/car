using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales_Mini.Common.Helper
{
    public static class StringHelper
    {
        private static readonly Random _rng = new Random();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        public static string RandomString(int Size)
        {
            StringBuilder builder = new StringBuilder();
            Random r = new Random();
            for (int i = 0; i < Size; i++)
            {
                int randomNumber = r.Next(0, _chars.Length - 1);
                builder.Append(_chars[randomNumber]);
            }
            return builder.ToString();
        }
    }

}
