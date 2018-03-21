using System;

namespace ECS.WebAPI.Services.JsonSerialization
{
    public interface IJsonSerializationFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        T DeserializeObject<T>(string obj);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        string SerializeObject<T>(T obj);
    }
}
