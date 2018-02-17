using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ValuesRepo.Values.Select(v => $"{v.Key} - {v.Value}");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"{id} - {ValuesRepo.Values[id]}";
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

    }
}
