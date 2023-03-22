using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.CustomExtensions
{
    public static class CustomCookieExtension
    {
        public static void SetObject<T>(this HttpResponse response, string key, T value) where T : class, new()
        {
            var stringData = JsonConvert.SerializeObject(value);
            response.Cookies.Append(key, stringData, new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1) });
        }

        public static T GetObject<T>(this HttpRequest request, string key) where T : class, new()
        {
            var jsonData = request.Cookies[key];
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return null;
        }
    }
}
