using Newtonsoft.Json;

namespace Runtime.Extensions
{
    public static class JsonConvertTool
    {
        public static T ToJsonObject<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string ToJsonString<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}