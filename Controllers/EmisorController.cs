using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using exanim.Models;

namespace exanim.Controllers
{
    [Route("api/[controller]")]
    public class EmisorController : Controller
    {
        private readonly NimCtx _ctx;

        public EmisorController(NimCtx context)
        {
            _ctx = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Emisor> Get()
        {
            List<Emisor> ls = _ctx.Emisores.ToList();

            return ls;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emisor>> Get(int id)
        {
            Emisor e = await _ctx.Emisores.FirstOrDefaultAsync(emi => emi.Id == id);
            if (e == null)
            {
                return NotFound();
            }
            return e;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Emisor>> Post([FromBody] Emisor emi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _ctx.Emisores.Update(emi);
                await _ctx.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = emi.Id }, emi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Emisor>> Put(int id, [FromBody] Emisor emi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != emi.Id)
            {
                return NotFound();
            }
            try
            {
                _ctx.Emisores.Update(emi);
                await _ctx.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = emi.Id }, emi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Emisor emi = _ctx.Emisores.Find(id);
            if (emi != null)
            {
                _ctx.Emisores.Remove(emi);
                _ctx.SaveChanges();
            }
        }
    }
}
