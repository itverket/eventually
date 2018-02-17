using System.Collections.Generic;

namespace Api.Controllers
{
    public static class ValuesRepo 
    {
        public static Dictionary<int, string> Values = new Dictionary<int, string>
        {
            {1, "first value!"},
            {2, "second value!"},
            {3, "third value!"},
        };
    }

}