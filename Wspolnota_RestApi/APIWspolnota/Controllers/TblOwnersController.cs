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
    public class TblOwnersController : ControllerBase
    {
        private readonly HousingAssociationContext _context;

        public TblOwnersController(HousingAssociationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Pobieranie Informacji o Wlascicielach
        /// </summary>
        /// <returns>FLista Wlascicieli</returns>
        // GET: api/TblOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblOwners>>> GetTblOwners()
        {
            return await _context.TblOwners.ToListAsync();
        }

        /// <summary>
        /// Pobieranie Informacji o Wlascicielu
        /// </summary>
        /// <param name="id">id wlasciciela</param>
        /// <returns>Wlasciciel o wskazanym id</returns>
        // GET: api/TblOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblOwners>> GetTblOwners(int id)
        {
            var tblOwners = await _context.TblOwners.FindAsync(id);

            if (tblOwners == null)
            {
                return NotFound();
            }

            return tblOwners;
        }

        // PUT: api/TblOwners/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblOwners(int id, TblOwners tblOwners)
        {
            if (id != tblOwners.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblOwners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblOwnersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblOwners
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblOwners>> PostTblOwners(TblOwners tblOwners)
        {
            _context.TblOwners.Add(tblOwners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblOwners", new { id = tblOwners.Id }, tblOwners);
        }

        // DELETE: api/TblOwners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblOwners>> DeleteTblOwners(int id)
        {
            var tblOwners = await _context.TblOwners.FindAsync(id);
            if (tblOwners == null)
            {
                return NotFound();
            }

            _context.TblOwners.Remove(tblOwners);
            await _context.SaveChangesAsync();

            return tblOwners;
        }

        private bool TblOwnersExists(int id)
        {
            return _context.TblOwners.Any(e => e.Id == id);
        }
    }
}
