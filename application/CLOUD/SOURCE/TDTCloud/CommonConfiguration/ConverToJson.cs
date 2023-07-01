using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommonConfiguration
{
    public static class ConverToJson<T>
    {
        /// <summary>
        /// ConverObjectToJson
        /// </summary>
        /// <param name="objRequest"></param>
        /// <returns></returns>
        public static string ConverObjectToJson(T objRequest)
        {
            var jsonString = JsonSerializer.Serialize(objRequest);
            return jsonString;
        }
    }
}
