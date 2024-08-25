using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Domain.Utilities
{
    public static class StringHelper
    {
        public static bool IsNumericText(this string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        public static string SecureEmail(this string email)
        {
            email = email.Split('@')[0];
            var emailLenght = email.Length;
            email = "..." + email.Substring(0, emailLenght - 1);

            return email;
        }

        public static string ToSlug(this string url)
        {
            return url.Trim().ToLower()
                .Replace("$", "")
                .Replace("+", "")
                .Replace("%", "")
                .Replace("?", "")
                .Replace("^", "")
                .Replace("*", "")
                .Replace("@", "")
                .Replace("!", "")
                .Replace("#", "")
                .Replace("&", "")
                .Replace("~", "")
                .Replace("(", "")
                .Replace("=", "")
                .Replace(")", "")
                .Replace("/", "")
                .Replace(@"\", "")
                .Replace(".", "")
                .Replace(" ", "-");
        }

        public static string ConvertHtmlToText(this string text)
        {
            return Regex.Replace(text, "<.*?>", " ")
                .Replace("&zwnj;", " ")
                .Replace(";&zwnj", " ")
                .Replace("&nbsp;", " ");
        }

        public static bool IsUnicode(this string value)
        {
            return value.Any(c => c > 255);
        }

        public static string MakeShort(this string text, int length)
        {
            if (text.Length > length)
            {
                return text.Substring(0, length - 3) + "...";
            }

            return text;
        }

        public static string GenerateCode(int length)
        {
            var random = new Random();
            var code = "";
            for (int i = 0; i < length; i++)
            {
                code += random.Next(0, 9).ToString();
            }

            return code;
        }

        
    }
}
