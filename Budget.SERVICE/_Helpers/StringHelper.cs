using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Budget.SERVICE._Helpers
{
    public static class StringHelper
    {
        public static string GetLogoUrl(string logoClassName,int logoSize)
        {
            if (logoClassName != null)
                return $"assets/images/Otf/{logoClassName}_{logoSize}.png";

            return $"assets/images/Otf/OtfInconnu_{logoSize}.png";
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        
    }

    public static class Utility
    {
        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}
