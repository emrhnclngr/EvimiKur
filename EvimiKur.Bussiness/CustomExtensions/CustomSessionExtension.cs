using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EvimiKur.Business.CustomExtensions
{
    public static class CustomSessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value) where T :class,new()
        {
            var stringDta = JsonConvert.SerializeObject(value);
            session.SetString(key,stringDta);
        }
        public static T GetObject<T>(this ISession session, string key) where T :class,new()
        {
            var jsonData = session.GetString(key);
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return null;
        }
    }
}
