using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWspolnota.Models;

namespace APIWspolnota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VwFlatsController : ControllerBase
    {
        private readonly HousingAssociationContext _context;

        public VwFlatsController(HousingAssociationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Pobieranie Informacji o Mieszkaniach
        /// </summary>
        /// <returns>Lista Mieszkan</returns>
        // GET: api/VwFlats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VwFlats>>> GetVwFlats()
        {
            return await _context.VwFlats.ToListAsync();
        }

        /* przez geometrie wszystko sie psuje :( */

        ///// <summary>
        ///// Pobieranie Informacji o Mieszkaniu
        ///// </summary>
        ///// <param name="id">id mieszkania</param>
        ///// <returns>Mieszkanie o wskazanym id</returns>
        //// GET: api/VwFlats/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<VwFlats>> GetVwFlats(int id)
        //{
        //    var tblFlats = await _context.VwFlats.FindAsync(id);

        //    if (tblFlats == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblFlats;
        //}

        //// PUT: api/VwFlats/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutVwFlats(int id, VwFlats tblFlats)
        //{
        //    if (id != tblFlats.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblFlats).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VwFlatsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/VwFlats
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<VwFlats>> PostVwFlats(VwFlats tblFlats)
        //{
        //    _context.VwFlats.Add(tblFlats);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetVwFlats", new { id = tblFlats.Id }, tblFlats);
        //}

        //// DELETE: api/VwFlats/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<VwFlats>> DeleteVwFlats(int id)
        //{
        //    var tblFlats = await _context.VwFlats.FindAsync(id);
        //    if (tblFlats == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.VwFlats.Remove(tblFlats);
        //    await _context.SaveChangesAsync();

        //    return tblFlats;
        //}

        private bool VwFlatsExists(int id)
        {
            return _context.VwFlats.Any(e => e.Id == id);
        }
    }
}
