using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solstice.Helper
{
    public static class Helper
    {
        public static string GetValueForKey(Dictionary<string,object> dic, string key)
        {
            var value = new Object();
            if (dic.TryGetValue(key, out value))
            {
                return value.ToString();
            }
            else
            {
                return "";
            }
        }

        internal static Dictionary<string, object> GetObjectForId(Dictionary<string, object> dic, string key)
        {
            var value = new Object();
            if (dic.TryGetValue(key, out value))
            {
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString());
            }
            else
            {
                return new Dictionary<string, object>();
            }
        }
    }
}