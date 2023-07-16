using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonApi
{
    /// <summary>
    /// CommonConverJsonToObject Generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonConverJsonToObject<T>
    {
        /// <summary>
        /// ConverJsonToObject
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ConverJsonToObject(string json)
        {
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        /// <summary>
        /// CoverObjectToJson
        /// </summary>
        /// <param name="objRequest"></param>
        /// <returns></returns>
        public static string CoverObjectToJson(T objRequest)
        {
            var jsonString = JsonConvert.SerializeObject(objRequest);
            return jsonString;
        }

    }
}
