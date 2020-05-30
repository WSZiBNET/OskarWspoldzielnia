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
    public class TblInvoicesController : ControllerBase
    {
        private readonly HousingAssociationContext _context;

        public TblInvoicesController(HousingAssociationContext context)
        {
            _context = context;
        }

        // GET: api/TblInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblInvoices>>> GetTblInvoices()
        {
            return await _context.TblInvoices.ToListAsync();
        }

        // GET: api/TblInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblInvoices>> GetTblInvoices(int id)
        {
            var tblInvoices = await _context.TblInvoices.FindAsync(id);

            if (tblInvoices == null)
            {
                return NotFound();
            }

            return tblInvoices;
        }

        // PUT: api/TblInvoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblInvoices(int id, TblInvoices tblInvoices)
        {
            if (id != tblInvoices.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblInvoices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblInvoicesExists(id))
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

        // POST: api/TblInvoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblInvoices>> PostTblInvoices(TblInvoices tblInvoices)
        {
            _context.TblInvoices.Add(tblInvoices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblInvoices", new { id = tblInvoices.Id }, tblInvoices);
        }

        // DELETE: api/TblInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblInvoices>> DeleteTblInvoices(int id)
        {
            var tblInvoices = await _context.TblInvoices.FindAsync(id);
            if (tblInvoices == null)
            {
                return NotFound();
            }

            _context.TblInvoices.Remove(tblInvoices);
            await _context.SaveChangesAsync();

            return tblInvoices;
        }

        private bool TblInvoicesExists(int id)
        {
            return _context.TblInvoices.Any(e => e.Id == id);
        }
    }
}
