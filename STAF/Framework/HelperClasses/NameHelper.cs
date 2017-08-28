using System;
using System.Linq;

namespace STAF.Framework.HelperClasses
{
    class NameHelper
    {
        private static Random random = new Random();
        internal static string RandomName(int length)
        {
            const string _chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            return new string(Enumerable.Repeat(_chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        internal static string WithSpecialCharacters(int length)
        {
            const string _chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            const string _specialChars = "!@#$%^&*&^%$#@!@#$%^&*&^%$#@^";
            return new string(Enumerable.Repeat(_chars + _specialChars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        internal static string WithNumbers(int length)
        {
            const string _chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            const string _numbers = "01234567898765432123456789";
            return new string(Enumerable.Repeat(_chars + _numbers, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        internal static string WithCombination(int length)
        {
            const string _chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            const string _numbers = "01234567898765432123456789";
            const string _specialChars = "!@#$%^&*&^%$#@!@#$%^&*&^%$#@^";
            return new string(Enumerable.Repeat(_chars + _numbers + _specialChars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // To make random email use this code: NameGenerator.RandomName(8) + "@mail.com"
    }
}
