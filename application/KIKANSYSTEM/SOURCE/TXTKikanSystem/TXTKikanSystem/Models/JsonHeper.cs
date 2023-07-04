using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TXTKikanSystem.Models
{
    public class JsonHeper<T>
    {
        public static string CoverObjectToJson(T objRequest)
        {
            var jsonString = JsonSerializer.Serialize(objRequest);
            return jsonString;
        }
    }
}
