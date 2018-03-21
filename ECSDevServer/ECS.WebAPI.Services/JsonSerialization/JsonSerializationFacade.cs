using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ECS.WebAPI.Services.JsonSerialization
{
    /// <summary>
    /// Generic static service class to Serialize and Deserialize Json objects.
    /// </summary>
    public static class JsonSerializationFacade
    {
        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}