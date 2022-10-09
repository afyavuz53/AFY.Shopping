using Afy.Shopping.Core.Common.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.Core.Common.Services
{
    internal class NewtonSoftService : ISerializerService
    {
        public T? Deserialize<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text ?? string.Empty);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public string Serialize<T>(T obj, Type type)
        {
            return JsonConvert.SerializeObject(obj, type, new());
        }
    }
}
