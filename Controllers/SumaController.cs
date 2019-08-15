using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using exanim.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace exanim.Controllers
{
    [Route("api/[controller]")]
    public class SumaController : Controller
    {
        // GET: api/values
        [HttpPost("{par}/{met}")]
        public List<List<int>> Get(int par, int met, [FromBody] List<int> recur)
        {
            List<List<int>> reg = Revisa(met, par, recur);

            return reg;
        }

        private List<List<int>> Revisa(int meta, int largo, List<int> lista)
        {
            List<List<int>> ls = new List<List<int>>();
            var cuadrado = lista.Cuadro(largo);
            foreach (var c in cuadrado)
            {
                if (meta == c.Sum())
                {
                    List<int> agr = c.ToList();
                    ls.Add(agr);
                }
            }
            return ls;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
