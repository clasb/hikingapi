using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingApi.Model
{
    public static class IdHelper
    {
        public static string GetId()
        {
            var guid = Guid.NewGuid();
            string id = Convert.ToBase64String(guid.ToByteArray());
            id = id.Replace("=", "");
            id = id.Replace("+", "");
            id = id.Replace("/", "");
            return id;
        }
    }
}
